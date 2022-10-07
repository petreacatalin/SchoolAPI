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
using System.Collections.Immutable;

namespace School.Services.Services.Implementation
{
    public class ClassService : IClassService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClassService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Response<ClassDto> Get(int? skip, int? take, string filter, bool includeDeleted)
        {
            var result = _unitOfWork.ClassRepository.GetAll();

            var totalCount = result.Count();

            if (filter != null)
            {
                result = result.Where(x => x.Location.Contains(filter) || x.Title.Contains(filter));
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
            var items = new Response<ClassDto>
            {
                Total = $"{filteredCount} of {totalCount}",
                Items = result.Select(x => _mapper.Map<ClassDto>(x))
            };
            return items;
        }
        public async Task<Response<StudentDto>> GetClassStudents(Guid? classId, int? skip, int? take, string filter = null)
        {
            var classItem = await _unitOfWork.ClassRepository.SingleOrDefaultAsync(filter: x => x.Id == classId);
            var studentClass = _unitOfWork.StudentClassRepository.GetAll(include: x => x.Include(x => x.Student)).Where(m => m.ClassId == classItem.Id);


            var result = studentClass.Select(x => x.Student);

            var totalCount = result.Count();           

            var total = result.Count();

            if (filter != null)
            {
                result = result.Where(x => x.FirstName.Contains(filter) || x.City.Contains(filter));
            }           

            if (skip.HasValue)
            {
                result = result.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                result = result.Take(take.Value);
            }
            var filtered = result.Count();
            var response = new Response<StudentDto>
            {
                Total = $"{filtered} of {total}",
                Items = result.Select(x => _mapper.Map<StudentDto>(x))
            };

            return response;
        }
        public async Task<ClassDto> GetByIdAsync(Guid? id)
        {
            var result = await _unitOfWork.ClassRepository.SingleOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<ClassDto>(result);
        }

        public async Task<ClassRequestDto> AddAsync(ClassRequestDto classModel)
        {
            Class entity = _mapper.Map<Class>(classModel);
            entity.Id = Guid.NewGuid();            
            Class itemResult = await _unitOfWork.ClassRepository.InsertAsync(entity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ClassRequestDto>(itemResult);
        }

        public async Task UpdateAsync(ClassRequestDto classModel, Guid? id)
        {
            Class entity = await _unitOfWork.ClassRepository.SingleOrDefaultAsync(filter: f => f.Id == id);
            _mapper.Map(classModel, entity);
            _unitOfWork.ClassRepository.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Guid? id)
        {
            var classModel = await _unitOfWork.ClassRepository.SingleOrDefaultAsync(filter: f => f.Id == id);
            _unitOfWork.ClassRepository.Delete(classModel);
            await _unitOfWork.SaveAsync();
        }
    }
}
