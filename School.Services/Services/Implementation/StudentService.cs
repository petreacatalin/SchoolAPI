using AutoMapper;
using School.Data.Entities;
using School.DTOs.Dtos.PostDtos;
using School.DTOs.Dtos;
using School.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Services.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace School.Services.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Response<StudentDto> Get(int? skip, int? take, string filter, DateTimeOffset? enrollDate, DateTimeOffset? finishDate, bool includeDeleted)
        {
            var result = _unitOfWork.StudentRepository.GetAll();

            var totalCount = result.Count();

            if (filter != null)
            {
                result = result.Where(x => x.City.Contains(filter) || x.FirstName.Contains(filter) || x.LastName.Contains(filter) || x.Email.Contains(filter));
            }

            if (!includeDeleted)
            {
                result = result.Where(x => x.IsDeleted == includeDeleted);
            }

            if (enrollDate.HasValue)
            {
                result = result.Where(x => x.EnrollmentDate >= enrollDate.Value);
            }

            if (finishDate.HasValue)
            {
                result = result.Where(x => x.EnrollmentDate <= finishDate.Value);
            }

            if (skip.HasValue)
            {
                result = result.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                result = result.Take(take.Value);
            }

            var filteredCount = result.Count();
            var items = new Response<StudentDto>
            {
                Total = $"{filteredCount} of {totalCount}",
                Items = result.Select(x => _mapper.Map<StudentDto>(x))
            };
            return items;
        }
        public Response<GradeDto> GetGradesByStudentAndProfessorID(Guid? id, Guid? professorId, DateTimeOffset? beginDate, DateTimeOffset? finishDate, int? skip, int? take, string filter = null)
        {
            var result = _unitOfWork.GradeRepository.GetAll(include: x => x.Include(x => x.Professor).Include(x => x.Student).ThenInclude(x => x.Grades),
                                                            filter: f => f.ProfessorId == professorId && f.Student.Id == id);

            var total = result.Count();

            if (filter != null)
            {
                result = result.Where(x => x.Comment.Contains(filter));
            }

            if (beginDate.HasValue)
            {
                result = result.Where(x => x.Date >= beginDate.Value);
            }

            if (finishDate.HasValue)
            {
                result = result.Where(x => x.Date <= finishDate.Value);
            }

            if (skip.HasValue)
            {
                result = result.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                result = result.Take(take.Value);
            }

            var filteredCount = result.Count();
            var response = new Response<GradeDto>
            {
                Total = $"{total} of {filteredCount}",
                Items = result.Select(x => _mapper.Map<GradeDto>(x))
            };
            return response;

        }
        public async Task<StudentDto> GetByIdAsync(Guid? id)
        {
            var result = await _unitOfWork.StudentRepository.SingleOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<StudentDto>(result);
        }

        public async Task<StudentRequestDto> AddAsync(StudentRequestDto student)
        {
            Student entity = _mapper.Map<Student>(student);
            entity.Id = Guid.NewGuid();
            Student itemResult = await _unitOfWork.StudentRepository.InsertAsync(entity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<StudentRequestDto>(itemResult);
        }

        public async Task UpdateAsync(StudentRequestDto student, Guid? id)
        {
            Student entity = await _unitOfWork.StudentRepository.SingleOrDefaultAsync(filter: f => f.Id == id);
            _mapper.Map(student, entity);
            _unitOfWork.StudentRepository.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Guid? id)
        {
            var student = await _unitOfWork.StudentRepository.SingleOrDefaultAsync(filter: f => f.Id == id);
            _unitOfWork.StudentRepository.Delete(student);
            await _unitOfWork.SaveAsync();
        }



    }
}
