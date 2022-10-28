using AutoMapper;
using InvoiceApp.Application.Models.Debtor;
using InvoiceApp.Core.Entities;

namespace InvoiceApp.Application.MappingProfiles;

public class DebtorProfile : Profile
{
    public DebtorProfile()
    {
        // CreateMap<Debtor, DebtorResponseModel>()
        //     .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id))
        //     .ForMember(dto => dto.FirstName, opt => opt.MapFrom(src => src.FirstName))
        //     .ForMember(dto => dto.LastName, opt => opt.MapFrom(src => src.LastName))
        //     .ForMember(dto => dto.CompanyName, opt => opt.MapFrom(src => src.CompanyName))
        //     .ForMember(dto => dto.Address, opt => opt.MapFrom(src => src.Address))
        //     .ForMember(dto => dto.HouseNumber, opt => opt.MapFrom(src => src.HouseNumber))
        //     .ForMember(dto => dto.ZipCode, opt => opt.MapFrom(src => src.ZipCode))
        //     .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.City))
        //     .ForMember(dto => dto.Country, opt => opt.MapFrom(src => src.Country))
        //     .ForMember(dto => dto.Email, opt => opt.MapFrom(src => src.Email));

        CreateMap<Debtor, DebtorResponseModel>();
        
        CreateMap<CreateDebtorModel, Debtor>();
        CreateMap<UpdateDebtorModel, Debtor>();
    }
}