using School.DTOs.Dtos;
using School.DTOs.Dtos.PostDtos;
using System;
using System.Threading.Tasks;

namespace School.Services.Services.Contracts
{
    public interface IProfessorService
    {
        Task<ProfessorRequestDto> AddAsync(ProfessorRequestDto professor);
        Task DeleteAsync(Guid? id);
        Response<ProfessorDto> Get(int? skip, int? take, DateTimeOffset? hireDate, DateTimeOffset? finishDate,string filter, bool includeDeleted);
        Task<ProfessorDto> GetByIdAsync(Guid? id);
        Task UpdateAsync(ProfessorRequestDto professor, Guid? id);
    }
}