using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School.Data.Entities;
using School.DTOs.Dtos;
using School.DTOs.Dtos.PostDtos;
using School.Repositories.UnitOfWork;
using School.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.Services.Implementation
{
    public class ProfessorService : IProfessorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProfessorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Response<ProfessorDto> Get(int? skip, int? take, DateTimeOffset? hireDate, DateTimeOffset? finishDate, string filter, bool includeDeleted)
        {
            var result = _unitOfWork.ProfessorRepository.GetAll(include: i => i
                                                        .Include(i => i.Office));

            var total = result.Count();

            if (filter != null)
            {
                result = result.Where(x => x.FirstName.Contains(filter) || x.LastName.Contains(filter));
            }

            if (!includeDeleted)
            {
                result = result.Where(x => x.IsDeleted == includeDeleted);
            }

            if (skip.HasValue)
            {
                result = result.Skip(skip.Value);
            }

            if (hireDate.HasValue)
            {
                result = result.Where(x => x.HireDate >= hireDate.Value);
            }

            if (finishDate.HasValue)
            {
                result = result.Where(x => x.HireDate <= finishDate.Value);
            }

            if (take.HasValue)
            {
                result = result.Take(take.Value);
            }

            var filterTotal = result.Count();
            var items = new Response<ProfessorDto>
            {
                Total = $"{filterTotal} of {total}",
                Items = result.Select(x => _mapper.Map<ProfessorDto>(x))
            };
            return items;
        }

        public async Task<ProfessorDto> GetByIdAsync(Guid? id)
        {
            var result = await _unitOfWork.ProfessorRepository.SingleOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<ProfessorDto>(result);
        }

        public async Task<ProfessorRequestDto> AddAsync(ProfessorRequestDto professor)
        {
            Professor entity = _mapper.Map<Professor>(professor);
            entity.Id = Guid.NewGuid();
            Professor itemResult = await _unitOfWork.ProfessorRepository.InsertAsync(entity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<ProfessorRequestDto>(itemResult);
        }

        public async Task UpdateAsync(ProfessorRequestDto professor, Guid? id)
        {
            Professor entity = await _unitOfWork.ProfessorRepository.SingleOrDefaultAsync(filter: f => f.Id == id);
            _mapper.Map(professor, entity);
            _unitOfWork.ProfessorRepository.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Guid? id)
        {
            var card = await _unitOfWork.ProfessorRepository.SingleOrDefaultAsync(filter: f => f.Id == id);
            _unitOfWork.ProfessorRepository.Delete(card);
            await _unitOfWork.SaveAsync();
        }
    }
}
