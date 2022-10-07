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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Get Students
        /// </summary>
        [Authorize(Roles = "Professor, Manager")]
        [HttpGet]
        public Response<StudentDto> Get(int? skip, int? take, DateTimeOffset? enrollDate, DateTimeOffset? finishDate, string filter = null,  bool includeDeleted = false)
        {
            return _studentService.Get(skip, take, filter, enrollDate, finishDate, includeDeleted);
        }

        /// <summary>
        /// Get Student by Id
        /// </summary>
        [Authorize(Roles = "Student, Professor")]
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetByIdAsync(Guid id)
        {
            var item = await _studentService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        /// <summary>
        /// Get Grades by StudentId and ProfessorId
        /// </summary>
        [Authorize(Roles = "Professor")]
        [HttpGet("{id}/Professor/{professorId}/Grades")]
        public Response<GradeDto> GetGradesByStudentAndProfessorID(Guid id, Guid professorId, DateTimeOffset? beginDate, DateTimeOffset? finishDate, int? skip, int? take, string filter = null)
        {
            return _studentService.GetGradesByStudentAndProfessorID(id, professorId, beginDate, finishDate, skip, take, filter);
        }

        /// <summary>
        /// Post Student
        /// </summary>
        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] StudentRequestDto office)
        {
            if (ModelState.IsValid)
            {
                await _studentService.AddAsync(office);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Put Student
        /// </summary>
        [Authorize(Roles = "Manager")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] StudentRequestDto office)
        {
            if (ModelState.IsValid)
            {
                await _studentService.UpdateAsync(office, id);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Delete Student
        /// </summary>
        [Authorize(Roles = "Manager")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _studentService.DeleteAsync(id);

            return Ok();
        }

       
    }
    
}
