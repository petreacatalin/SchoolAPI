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
using System.Diagnostics;
using School.Services.Services.Contracts;

namespace School.Services.Services.Implementation
{
    public class GradeService : IGradeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GradeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Response<GradeDto> Get(int? skip, int? take, string filter, bool includeDeleted)
        {
            var result = _unitOfWork.GradeRepository.GetAll();

            var totalCount = result.Count();

            if (filter != null)
            {
                result = result.Where(x => x.Comment.Contains(filter));
            }

            if (!includeDeleted)
            {
                result = result.Where(x => x.IsDeleted == includeDeleted);
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
            var items = new Response<GradeDto>
            {
                Total = $"{filteredCount} of {totalCount}",
                Items = result.Select(x => _mapper.Map<GradeDto>(x))
            };
            return items;
        }

        public Response<GradeDto> GetProfessorGrades(Guid professorId, int? skip, int? take, string filter = null)
        {
            var result = _unitOfWork.GradeRepository.GetAll(filter: f => f.ProfessorId == professorId);
            var total = result.Count();

            if (filter != null)
            {
                result = result.Where(x => x.Comment.Contains(filter));
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

        public Response<GradeDto> GetStudentGrades(Guid studentId, int? skip, int? take, string filter = null)
        {
            var result = _unitOfWork.GradeRepository.GetAll(filter: f => f.StudentId == studentId);
            var total = result.Count();

            if (filter != null)
            {
                result = result.Where(x => x.Comment.Contains(filter));
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

        public async Task<GradeDto> GetByIdAsync(Guid? id)
        {
            var result = await _unitOfWork.GradeRepository.SingleOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<GradeDto>(result);
        }

        public async Task<GradeRequestDto> AddAsync(GradeRequestDto grade)
        {
            Grade entity = _mapper.Map<Grade>(grade);
            entity.Id = Guid.NewGuid();
            Grade itemResult = await _unitOfWork.GradeRepository.InsertAsync(entity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<GradeRequestDto>(itemResult);
        }

        public async Task UpdateAsync(GradeRequestDto grade, Guid? id)
        {
            Grade entity = await _unitOfWork.GradeRepository.SingleOrDefaultAsync(filter: f => f.Id == id);
            _mapper.Map(grade, entity);
            _unitOfWork.GradeRepository.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Guid? id)
        {
            var grade = await _unitOfWork.GradeRepository.SingleOrDefaultAsync(filter: f => f.Id == id);
            _unitOfWork.GradeRepository.Delete(grade);
            await _unitOfWork.SaveAsync();
        }
    }
}
