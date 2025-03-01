namespace Application.Mapping
{
    public class MappingProfile
        : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterUserDto, User>()
                .ForMember(dest => dest.UserId,
                    opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.PasswordHash,
                     opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Topics,
                    opt => opt.MapFrom(src => new List<Topic>()));

            CreateMap<Topic, ResponseTopicDto>();

            CreateMap<UpdateTopicDto, Topic>();

            CreateMap<CreateTopicDto, Topic>()
                .ForMember(dest => dest.TopicId,
                    opt => opt.MapFrom(src => Guid.NewGuid()));
        }
    }
}