using ClosedXML.Excel;
using Microsoft.VisualBasic;
using School.Data.Entities;
using School.Services.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.Services.Extensions
{
    public static class ExcelSheetExtension
    {
        public static void PlaceTitle(this IXLWorksheet worksheet, string title)
        {
            worksheet.Cell(3,2).Value = title;
        }

        public static void PlaceProfessorDetails(this IXLWorksheet worksheet, IEnumerable<Grade> professors)
        {
            worksheet.Cell(4, 1).Value = ExportConstants.ColumnScore;
            worksheet.Cell(4, 2).Value = ExportConstants.ColumnDate;
            worksheet.Cell(4, 3).Value = ExportConstants.ColumnComment;
            worksheet.Cell(4, 4).Value = ExportConstants.ColumnStudent;
            worksheet.Cell(4, 5).Value = ExportConstants.ColumnProfessorName;
            worksheet.Cell(4, 6).Value = ExportConstants.ColumnClassTitle;
                   
            var currentColumn = 5;

            foreach (var professor in professors)
            {
                worksheet.Cell(currentColumn, 1).Value = professor.Score;
                worksheet.Cell(currentColumn, 2).Value = professor.Date;
                worksheet.Cell(currentColumn, 3).Value = professor.Comment;               
                worksheet.Cell(currentColumn, 4).Value = (professor.Student.FirstName + " " + professor.Student.LastName);
                worksheet.Cell(currentColumn, 5).Value = (professor.Professor.FirstName + " " + professor.Professor.LastName);              
                worksheet.Cell(currentColumn, 6).Value = professor.Professor.Class.Title;              
                            
                currentColumn++;                
            }
            worksheet.Cell(currentColumn + 1, 1).Value = "TOTAL";
            worksheet.Cell(currentColumn + 1, 3).Value = professors.Count();
            
        }


        public static void PlaceStudentDetails(this IXLWorksheet worksheet, IEnumerable<Grade> students)
        {
            worksheet.Cell(4, 1).Value = ExportConstants.ColumnScore;
            worksheet.Cell(4, 2).Value = ExportConstants.ColumnDate;
            worksheet.Cell(4, 3).Value = ExportConstants.ColumnComment;
            worksheet.Cell(4, 4).Value = ExportConstants.ColumnStudent;
            worksheet.Cell(4, 5).Value = ExportConstants.ColumnProfessorName;
            worksheet.Cell(4, 6).Value = ExportConstants.ColumnClassTitle;

            var currentColumn = 5;

            foreach (var student in students)
            {
                worksheet.Cell(currentColumn, 1).Value = student.Score;
                worksheet.Cell(currentColumn, 2).Value = student.Date;
                worksheet.Cell(currentColumn, 3).Value = student.Comment;
                worksheet.Cell(currentColumn, 4).Value = (student.Student.FirstName + " " + student.Student.LastName);
                worksheet.Cell(currentColumn, 5).Value = (student.Professor.FirstName + " " + student.Professor.LastName);
                worksheet.Cell(currentColumn, 6).Value = student.Professor.Class.Title;

                currentColumn++;
            }

            worksheet.Cell(currentColumn + 1, 1).Value = "TOTAL";
            worksheet.Cell(currentColumn + 1, 3).Value = students.Count();

        }

        public static void FormatForBeauty(this IXLWorksheet worksheet)
        {
            worksheet.Columns().AdjustToContents();
        }
    }
}
