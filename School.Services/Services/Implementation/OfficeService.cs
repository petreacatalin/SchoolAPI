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

namespace School.Services.Services.Implementation
{
    public class OfficeService : IOfficeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OfficeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Response<OfficeDto> Get(int? skip, int? take, string filter, bool includeDeleted)
        {
            var result = _unitOfWork.OfficeRepository.GetAll();

            var totalCount = result.Count();

            if (filter != null)
            {
                result = result.Where(x => x.Name.Contains(filter) || x.Description.Contains(filter));
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
            var items = new Response<OfficeDto>
            {
                Total = $"{filteredCount} of {totalCount}",
                Items = result.Select(x => _mapper.Map<OfficeDto>(x))
            };
            return items;
        }

        public async Task<OfficeDto> GetByIdAsync(Guid? id)
        {
            var result = await _unitOfWork.OfficeRepository.SingleOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<OfficeDto>(result);
        }

        public async Task<OfficeRequestDto> AddAsync(OfficeRequestDto card)
        {
            Office entity = _mapper.Map<Office>(card);
            entity.Id = Guid.NewGuid();
            Office itemResult = await _unitOfWork.OfficeRepository.InsertAsync(entity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<OfficeRequestDto>(itemResult);
        }

        public async Task UpdateAsync(OfficeRequestDto card, Guid? id)
        {
            Office entity = await _unitOfWork.OfficeRepository.SingleOrDefaultAsync(filter: f => f.Id == id);
            _mapper.Map(card, entity);
            _unitOfWork.OfficeRepository.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Guid? id)
        {
            var card = await _unitOfWork.OfficeRepository.SingleOrDefaultAsync(filter: f => f.Id == id);
            _unitOfWork.OfficeRepository.Delete(card);
            await _unitOfWork.SaveAsync();
        }
    }
}
