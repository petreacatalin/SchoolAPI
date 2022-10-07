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
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        /// <summary>
        /// Get Classes by filters
        /// </summary>
        [Authorize]
        [HttpGet]
        public Response<ClassDto> Get(int? skip, int? take, string filter = null, bool includeDeleted = false)
        {
            return _classService.Get(skip, take, filter, includeDeleted);
        }

        /// <summary>
        /// Get Classes by Id
        /// </summary>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassDto>> GetByIdAsync(Guid id)
        {
            var item = await _classService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        /// <summary>
        /// Get Students by ClassId
        /// </summary>
        [Authorize(Roles = "Professor, Manager")]
        [HttpGet("{classId}/Students")]
        public async Task<Response<StudentDto>> GetClassStudents(Guid? classId, int? skip, int? take, string filter = null)
        {
            return await _classService.GetClassStudents(classId, skip, take, filter);
        }

        /// <summary>
        /// Post Class
        /// </summary>
        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] ClassRequestDto classModel)
        {
            if (ModelState.IsValid)
            {

                await _classService.AddAsync(classModel);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Put Class
        /// </summary>
        [Authorize(Roles = "Manager")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] ClassRequestDto classModel)
        {
            if (ModelState.IsValid)
            {
                await _classService.UpdateAsync(classModel, id);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Delete Class
        /// </summary>
        [Authorize(Roles = "Manager")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _classService.DeleteAsync(id);

            return Ok();
        }
    }
}

