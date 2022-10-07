using Microsoft.AspNetCore.Mvc;
using School.DTOs.Dtos.PostDtos;
using School.DTOs.Dtos;
using School.Services.Services.Contracts;
using System.Threading.Tasks;
using System;
using School.Data.Entities;
using Microsoft.AspNetCore.Authorization;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeService _officeService;

        public OfficeController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        /// <summary>
        /// Get Offices
        /// </summary>
        [Authorize(Roles = "Professor, Manager")]
        [HttpGet]
        public Response<OfficeDto> Get(int? skip, int? take, string filter = null, bool includeDeleted = false)
        {
            return _officeService.Get(skip, take, filter, includeDeleted);
        }

        /// <summary>
        /// Get Office by Id
        /// </summary>
        [Authorize(Roles = "Professor, Manager")]
        [HttpGet("{id}")]
        public async Task<ActionResult<OfficeDto>> GetByIdAsync(Guid id)
        {
            var item = await _officeService.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        /// <summary>
        /// Post Office
        /// </summary>
        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] OfficeRequestDto office)
        {
            if (ModelState.IsValid)
            {
                await _officeService.AddAsync(office);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Put Office
        /// </summary>
        [Authorize(Roles = "Manager")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] OfficeRequestDto office)
        {
            if (ModelState.IsValid)
            {
                await _officeService.UpdateAsync(office, id);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Delete Office
        /// </summary>
        [Authorize(Roles = "Manager")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _officeService.DeleteAsync(id);

            return Ok();
        }
    }
}
