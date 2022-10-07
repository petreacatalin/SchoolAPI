using School.DTOs.Dtos;
using School.DTOs.Dtos.PostDtos;
using System;
using System.Threading.Tasks;

namespace School.Services.Services.Contracts
{
    public interface IStudentService
    {
        Response<StudentDto> Get(int? skip, int? take, string filter, DateTimeOffset? enrollDate, DateTimeOffset? finishDate, bool includeDeleted);
        Task<StudentDto> GetByIdAsync(Guid? id);
        Response<GradeDto> GetGradesByStudentAndProfessorID(Guid? id, Guid? professorId, DateTimeOffset? beginDate, DateTimeOffset? finishDate, int? skip, int? take, string filter = null);
        Task<StudentRequestDto> AddAsync(StudentRequestDto student);
        Task UpdateAsync(StudentRequestDto student, Guid? id);
        Task DeleteAsync(Guid? id);
        
    }
}