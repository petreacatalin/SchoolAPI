using Microsoft.AspNetCore.Mvc;
using School.DTOs.Dtos.PostDtos;
using School.DTOs.Dtos;
using School.Services.Services.Contracts;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }
        /// <summary>
        /// Get Grades by filters
        /// </summary>
        [Authorize(Roles = "Student, Professor")]
        [HttpGet]
        public Response<GradeDto> Get(int? skip, int? take, string filter = null, bool includeDeleted = false)
        {
            return _gradeService.Get(skip, take, filter, includeDeleted);
        }

        /// <summary>
        /// Get Grades by StudentId
        /// </summary>
        [Authorize(Roles = "Student, Professor")]
        [HttpGet("{studentId}/Student")]
        public Response<GradeDto> GetStudentGrades(Guid studentId, int? skip, int? take, string filter = null)
        {
            return _gradeService.GetStudentGrades(studentId, skip, take, filter);
        }

        /// <summary>
        /// Get Grade by Id
        /// </summary>
        [Authorize(Roles = "Student, Professor")]
        [HttpGet("{id}")]
        public async Task<ActionResult<GradeDto>> GetByIdAsync(Guid id)
        {
            var item = await _gradeService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        /// <summary>
        /// Post Grade
        /// </summary>
        [Authorize(Roles = "Professor")]
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] GradeRequestDto grade)
        {
            if (ModelState.IsValid)
            {
                await _gradeService.AddAsync(grade);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Get Grades by ProfessorId
        /// </summary>
        [Authorize(Roles = "Professor")]
        [HttpGet("{professorId}/Professor")]
        public Response<GradeDto> GetProfessorGrades(Guid professorId, int? skip, int? take, string filter = null)
        {
            return _gradeService.GetProfessorGrades(professorId, skip, take, filter);
        }

        /// <summary>
        /// Put Grade
        /// </summary>
        [Authorize(Roles = "Professor")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] GradeRequestDto grade)
        {
            if (ModelState.IsValid)
            {
                await _gradeService.UpdateAsync(grade, id);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Delete Grade
        /// </summary>
        [Authorize(Roles = "Professor")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _gradeService.DeleteAsync(id);

            return Ok();
        }
    }
}
