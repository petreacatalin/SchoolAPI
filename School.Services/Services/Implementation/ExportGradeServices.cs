using AutoMapper;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.Repositories.UnitOfWork;
using School.Services.Services.Contracts;
using School.Services.Services.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.Services.Implementation
{
    public class ExportGradeServices : IExportGradeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExportGradeServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<Grade> GetProfessorGrades(IEnumerable<Guid> professors)
        {
            var grades = _unitOfWork.GradeRepository.GetAll(filter: f => f.Professor != null && professors.Contains(f.ProfessorId),
                                                            orderBy: o => o.OrderBy(s => s.ProfessorId).ThenBy(x => x.StudentId),
                                                            include: i => i.Include(x => x.Student)
                                                                           .ThenInclude(x => x.Grades)
                                                                           .Include(p => p.Professor)
                                                                           .ThenInclude(x => x.Class));
            return grades;

        }

        public IEnumerable<Grade> GetStudentGrades(IEnumerable<Guid> students)
        {
            var grades = _unitOfWork.GradeRepository.GetAll(filter: f => f.Student != null && students.Contains(f.StudentId),
                                                            orderBy: o => o.OrderBy(s => s.StudentId).ThenBy(x => x.ProfessorId),
                                                            include: i => i.Include(x => x.Student)
                                                                           .ThenInclude(x => x.Grades)
                                                                           .Include(p => p.Professor)
                                                                           .ThenInclude(x => x.Class));
            return grades;
        }

        public byte[] ExportProfessorGradesToExcel(IEnumerable<Guid> professors)
        {
            var grades = GetProfessorGrades(professors);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("All Grades");

                worksheet.PlaceTitle("Total Grades by Professors");
                worksheet.PlaceProfessorDetails(grades);
                worksheet.FormatForBeauty();
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return content;
                }
            }

        }

        public byte[] ExportStudentGradesToExcel(IEnumerable<Guid> students)
        {
            var grades = GetStudentGrades(students);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("All Grades");

                worksheet.PlaceTitle("Total Grades by Students");
                worksheet.PlaceStudentDetails(grades);
                worksheet.FormatForBeauty();
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return content;
                }
            }

        }
    }
}
