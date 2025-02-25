using Application.Dtos.Topics;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Topic, ResponseTopicDto>();

            CreateMap<UpdateTopicDto, Topic>();

            CreateMap<CreateTopicDto, Topic>();
        }
    }
}
