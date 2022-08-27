using AutoMapper;
using InvoiceApp.Application.Models.User;
using InvoiceApp.DataAccess.Identity;

namespace InvoiceApp.Application.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserModel, ApplicationUser>()
            .ForMember(dest => dest.UserName, act => act.MapFrom(src => src.Email));
    }
}