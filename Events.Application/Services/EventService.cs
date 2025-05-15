using AutoMapper;
using Events.Application.Dtos;
using Events.core.models;
using System.Linq.Expressions;
using WebApp.Core.Interfaces;

namespace WebApp.Application.Services
{
    public class EventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EventService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task AddAsync(AddEventDto dto)
        {
            var newEvent = _mapper.Map<AddEventDto, Event>(dto);
            await _unitOfWork.EventRepo.AddAsync(newEvent);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Event> GetByIdAsync(int id) => await _unitOfWork.EventRepo.GetAsync(c => c.Id == id);
   
        public async Task<IEnumerable<ReadEventDto>> GetAllAsync(Expression<Func<Event, bool>> filter = null!,
            bool isTracked = true, int pageSize = 0, int pageNumber = 0, params Expression<Func<Event, object>>[] includes)
        {
            var events = await _unitOfWork.EventRepo.GetAllAsync(filter: filter, isTracked: isTracked, pageSize: pageSize,
              pageNumber: pageNumber, includes: includes);
            var eventDtos = new List<ReadEventDto>();

            foreach (var item in events)
            {
                var eventDto = _mapper.Map<Event, ReadEventDto>(item);
                eventDtos.Add(eventDto);
            }
            return eventDtos;
        }


        public async Task UpdateAsync(UpdateEventDto dto)
        {
            var existingEvent = await GetByIdAsync(dto.Id);
            _mapper.Map(dto, existingEvent);
            _unitOfWork.EventRepo.Update(existingEvent);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var existedEvent = await _unitOfWork.EventRepo.GetAsync(c => c.Id == id);
            _unitOfWork.EventRepo.Remove(existedEvent);
            await _unitOfWork.SaveChangesAsync();
        }
    }

}
