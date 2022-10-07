using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using School.Data.Entities;
using School.Data.Entities.Abstraction;
using School.Repositories.Contracts;
using School.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.Services.Implementation
{
    public class ExportExcelsService
    {
        private const string StudentSheetName = "Students";
        private const string ProfessorSheetName = "Professors";
        private readonly IUnitOfWork _unitOfWork;

        public ExportExcelsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task RunAsync()
        {
            var students = await GetStudentsAsync();
            var professors = await GetProffesorsAsync();

            IWorkbook professorExcel = new XSSFWorkbook();
            IWorkbook studentExcel = new XSSFWorkbook();
            professorExcel.CreateSheet(ProfessorSheetName);
            studentExcel.CreateSheet(StudentSheetName);

            professorExcel = FillUserSheet<Professor>(professorExcel, professors, ProfessorSheetName);
            studentExcel = FillUserSheet<Student>(studentExcel, students, StudentSheetName);

            UploadFile(studentExcel, "Students");
            UploadFile(professorExcel, "Professors");
        }

        private IWorkbook FillUserSheet<T>(IWorkbook workbook, IReadOnlyList<T> data, string sheetName) where T : class, IUserInfo
        {
            var sheet = workbook.GetSheet(sheetName);
            sheet.CreateRow(0);
            var firstRow = sheet.GetRow(0);
            firstRow.CreateCell(0);
            firstRow.CreateCell(1);
            firstRow.CreateCell(2);
            
            firstRow.Cells[0].SetCellValue("First Name");
            firstRow.Cells[1].SetCellValue("Last Name");
            firstRow.Cells[2].SetCellValue("Email");           


            for (var index = 0; index < data.Count; index++)
            {
                sheet.CreateRow(index + 1);
                var row = sheet.GetRow(index + 1);
                row.CreateCell(0);
                row.CreateCell(1);
                row.CreateCell(2);               

                row.Cells[0].SetCellValue(data[index].FirstName);
                row.Cells[1].SetCellValue(data[index].LastName);
                row.Cells[2].SetCellValue(data[index].Email); 
            }

            sheet.DefaultColumnWidth = 50;
            return workbook;
        }

        private async Task<List<Student>> GetStudentsAsync()
        {
            return await _unitOfWork.StudentRepository.GetAll(include: i => i.Include(x => x.StudentClasses).ThenInclude(x => x.Class)).ToListAsync();
        }
        private async Task<List<Professor>> GetProffesorsAsync()
        {
            return await _unitOfWork.ProfessorRepository.GetAll(include: i => i.Include(x => x.Class).ThenInclude(x => x.StudentClasses)).ToListAsync();
        }
        private void UploadFile(IWorkbook workbook, string excelName)
        {
            var stream = new NpoiMemoryStream { AllowClose = false };
            workbook.Write(stream);
            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);
            stream.AllowClose = true;

            File.WriteAllBytes($"C:\\Sources\\{excelName}.xlsx", stream.ToArray());

        }

        private sealed class NpoiMemoryStream : MemoryStream
        {
            public NpoiMemoryStream()
            {
                // We always want to close streams by default to
                // force the developer to make the conscious decision
                // to disable it.  Then, they're more apt to remember
                // to re-enable it.  The last thing you want is to
                // enable memory leaks by default.  ;-)
                AllowClose = true;
            }

            public bool AllowClose { get; set; }

            public override void Close()
            {
                if (AllowClose)
                    base.Close();
            }
        }


    }

}
