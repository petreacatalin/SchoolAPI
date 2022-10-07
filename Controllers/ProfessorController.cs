using Microsoft.AspNetCore.Mvc;
using School.DTOs.Dtos;
using School.DTOs.Dtos.PostDtos;
using School.Services.Services.Contracts;
using School.Services.Services.Implementation;
using System.Threading.Tasks;
using System;
using School.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }
        /// <summary>
        /// Get Professors
        /// </summary>
        [Authorize(Roles = "Manager")]
        [HttpGet]
        public Response<ProfessorDto> Get(int? skip, int? take, DateTimeOffset? hireDate, DateTimeOffset? finishDate, string filter = null, bool includeDeleted = false)
        {
            return _professorService.Get(skip, take, hireDate, finishDate, filter, includeDeleted);
        }

        /// <summary>
        /// Get Professor by Id
        /// </summary>
        [Authorize(Roles = "Manager")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfessorDto>> GetByIdAsync(Guid id)
        {
            var item = await _professorService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        /// <summary>
        /// Post Professor
        /// </summary>
        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] ProfessorRequestDto professor)
        {
            if (ModelState.IsValid)
            {
                await _professorService.AddAsync(professor);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Put Professor
        /// </summary>
        [Authorize(Roles = "Manager")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] ProfessorRequestDto professor)
        {
            if (ModelState.IsValid)
            {
                await _professorService.UpdateAsync(professor, id);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Delete Professor
        /// </summary>
        [Authorize(Roles = "Manager")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _professorService.DeleteAsync(id);

            return Ok();
        }
    }
}

