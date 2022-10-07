using School.DTOs.Dtos;
using School.DTOs.Dtos.PostDtos;
using System;
using System.Threading.Tasks;

namespace School.Services.Services.Contracts
{
    public interface IGradeService
    {
        Response<GradeDto> Get(int? skip, int? take, string filter, bool includeDeleted);
        Task<GradeDto> GetByIdAsync(Guid? id);
        Response<GradeDto> GetProfessorGrades(Guid professorId, int? skip, int? take, string filter = null);
        Response<GradeDto> GetStudentGrades(Guid studentId, int? skip, int? take, string filter = null);
        Task<GradeRequestDto> AddAsync(GradeRequestDto grade);
        Task UpdateAsync(GradeRequestDto grade, Guid? id);
        Task DeleteAsync(Guid? id);
    }
}