using AutoMapper;
using Events.Application.Dtos;
using Events.core.models;

namespace WebApp.Application.Mappers
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<AddEventDto, Event>();
            CreateMap<UpdateEventDto, Event>();
            CreateMap<Event, ReadEventDto>();
        }

    }



}
