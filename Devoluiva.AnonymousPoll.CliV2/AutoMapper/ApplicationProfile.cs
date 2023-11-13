using AutoMapper;
using Devoluiva.AnonymousPoll.CliV2.Entities;
using Devoluiva.AnonymousPoll.Library.Models;

namespace Devoluiva.AnonymousPoll.CliV2.AutoMapper;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<StudentEntity, Student>().ReverseMap();
    }
}
