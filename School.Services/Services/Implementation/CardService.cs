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
    public class CardService : ICardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CardService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Response<CardDto> Get(int? skip, int? take, string filter, bool includeDeleted)
        {
            var result = _unitOfWork.CardRepository.GetAll(include: i => i
                                                   .Include(st => st.Student));

            var totalCount = result.Count();

            if (filter != null)
            {
                result = result.Where(x => x.City.Contains(filter) || x.SchoolName.Contains(filter));
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
            var items = new Response<CardDto>
            {
                Total = $"{filteredCount} of {totalCount}",
                Items = result.Select(x => _mapper.Map<CardDto>(x))
            };
            return items;
        }

        public async Task<CardDto> GetByIdAsync(Guid? id)
        {
            var result = await _unitOfWork.CardRepository.SingleOrDefaultAsync(c => c.Id == id);
            return _mapper.Map<CardDto>(result);
        }

        public async Task<CardRequestDto> AddAsync(CardRequestDto card)
        {
            Card entity = _mapper.Map<Card>(card);
            entity.Id = Guid.NewGuid();
            Card itemResult = await _unitOfWork.CardRepository.InsertAsync(entity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<CardRequestDto>(itemResult);
        }

        public async Task UpdateAsync(CardRequestDto card, Guid? id)
        {
            Card entity = await _unitOfWork.CardRepository.SingleOrDefaultAsync(filter: f => f.Id == id);
            _mapper.Map(card, entity);
            _unitOfWork.CardRepository.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Guid? id)
        {
            var card = await _unitOfWork.CardRepository.SingleOrDefaultAsync(filter: f => f.Id == id);
            _unitOfWork.CardRepository.Delete(card);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteStudentByCardIdAsync(Guid? cardId)
        {
            var student = await _unitOfWork.StudentRepository.SingleOrDefaultAsync(filter: f => f.Card.Id == cardId);
            _unitOfWork.StudentRepository.Delete(student);
            await _unitOfWork.SaveAsync();
        }
    }
}
