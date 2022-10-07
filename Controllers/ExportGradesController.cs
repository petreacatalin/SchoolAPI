using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Services.Services.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportGradesController : ControllerBase
    {
        private readonly IExportGradeServices _exportGradeServices;

        public ExportGradesController(IExportGradeServices exportGradeServices)
        {
            _exportGradeServices = exportGradeServices;
        }

        /// <summary>
        /// Export All Grades by ProfessorId
        /// </summary>
        [Authorize(Roles = "Professor")]
        [HttpPost("GradesByProfessor")]
        public ActionResult GradesByProfessor(IEnumerable<Guid> professors)
        {
            if (ModelState.IsValid)
            {
                return File(_exportGradeServices.ExportProfessorGradesToExcel(professors), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Professor Grades.xlsx");
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Export All Grades by StudentId
        /// </summary>
        [Authorize(Roles = "Student, Professor")]
        [HttpPost("GradesByStudent")]
        public ActionResult GradesByStudent(IEnumerable<Guid> students)
        {
            if (ModelState.IsValid)
            {
                return File(_exportGradeServices.ExportStudentGradesToExcel(students), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Students Grades.xlsx");
            }

            return BadRequest(ModelState);
        }


    }
}
