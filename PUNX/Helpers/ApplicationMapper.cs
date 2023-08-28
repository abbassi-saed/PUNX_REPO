using AutoMapper;
using PUNX.Domain.DTOs;
using PUNX.Domain.Entities;

namespace PUNX.API.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Job, ProjectJobDto>().ReverseMap();
            CreateMap<Sheet, JobSheetDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();

        }
    }
}
