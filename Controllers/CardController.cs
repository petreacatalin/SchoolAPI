using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.DTOs.Dtos;
using School.DTOs.Dtos.PostDtos;
using School.Repositories.Contracts;
using School.Services.Services.Contracts;
using School.Services.Services.Implementation;
using System;
using System.Threading.Tasks;

namespace SchoolAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        /// <summary>
        /// Get Cards by filters
        /// </summary>        
        [Authorize]
        [HttpGet]
        public Response<CardDto> Get(int? skip, int? take, string filter = null, bool includeDeleted = false)
        {
            return _cardService.Get(skip, take, filter, includeDeleted);
        }

        /// <summary>
        /// Get Card by Id
        /// </summary>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<CardDto>> GetByIdAsync(Guid id)
        {
            var card = await _cardService.GetByIdAsync(id);
            if (card == null)
            {
                return NotFound();
            }

            return card;
        }

        /// <summary>
        /// Post Card
        /// </summary>
        [Authorize(Roles = "Manager")]
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] CardRequestDto cardModel)
        {
            if (ModelState.IsValid)
            {
                await _cardService.AddAsync(cardModel);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Update Card
        /// </summary>
        [Authorize(Roles = "Manager")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] CardRequestDto cardModel)
        {
            if (ModelState.IsValid)
            {
                await _cardService.UpdateAsync(cardModel, id);
                return Ok();
            }

            return BadRequest(ModelState);

        }

        /// <summary>
        /// Delete Card
        /// </summary>
        [Authorize(Roles = "Manager")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _cardService.DeleteAsync(id);

            return Ok();
        }

        /// <summary>
        /// Delete Student by CardId
        /// </summary>
        [Authorize(Roles = "Manager")]
        [HttpDelete("{cardId}/Student")]
        public async Task<ActionResult> DeleteStudentByCardId(Guid? cardId)
        {
            if (cardId == null)
            {
                return NotFound();
            }

            await _cardService.DeleteStudentByCardIdAsync(cardId);

            return Ok();
        }
    }

}
