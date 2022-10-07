using School.DTOs.Dtos;
using School.DTOs.Dtos.PostDtos;
using System;
using System.Threading.Tasks;

namespace School.Services.Services.Contracts
{
    public interface IOfficeService
    {
        Task<OfficeRequestDto> AddAsync(OfficeRequestDto card);
        Task DeleteAsync(Guid? id);
        Response<OfficeDto> Get(int? skip, int? take, string filter, bool includeDeleted);
        Task<OfficeDto> GetByIdAsync(Guid? id);
        Task UpdateAsync(OfficeRequestDto card, Guid? id);
    }
}