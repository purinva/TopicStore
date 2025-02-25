using Application.Dtos.Topics;
using Application.Dtos.Users;
using Application.Security;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class MappingProfile
        : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterUserDto, User>()
                .ForMember(dest => dest.Id, 
                    opt => opt.MapFrom(src => Guid.NewGuid())) 
                .ForMember(dest => dest.PasswordHash, 
                     opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Topics, 
                    opt => opt.MapFrom(src => new List<Topic>())); 

            CreateMap<Topic, ResponseTopicDto>();

            CreateMap<UpdateTopicDto, Topic>();

            CreateMap<CreateTopicDto, Topic>();
        }
    }
}