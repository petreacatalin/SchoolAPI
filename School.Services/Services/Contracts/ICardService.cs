using School.DTOs.Dtos;
using School.DTOs.Dtos.PostDtos;
using System;
using System.Threading.Tasks;

namespace School.Services.Services.Contracts
{
    public interface ICardService
    {
        Task<CardRequestDto> AddAsync(CardRequestDto card);
        Response<CardDto> Get(int? skip, int? take, string filter, bool includeDeleted);
        Task<CardDto> GetByIdAsync(Guid? id);
        Task UpdateAsync(CardRequestDto card, Guid? id);
        Task DeleteAsync(Guid? id);
        Task DeleteStudentByCardIdAsync(Guid? cardId);
    }
}