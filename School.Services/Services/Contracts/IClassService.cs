using School.DTOs.Dtos;
using School.DTOs.Dtos.PostDtos;
using System;
using System.Threading.Tasks;

namespace School.Services.Services.Contracts
{
    public interface IClassService
    {
        Task<ClassRequestDto> AddAsync(ClassRequestDto classModel);
        Task DeleteAsync(Guid? id);
        Response<ClassDto> Get(int? skip, int? take, string filter, bool includeDeleted);
        Task<Response<StudentDto>> GetClassStudents(Guid? classId, int? skip, int? take, string filter = null);
        Task<ClassDto> GetByIdAsync(Guid? id);
        Task UpdateAsync(ClassRequestDto classModel, Guid? id);
    }
}