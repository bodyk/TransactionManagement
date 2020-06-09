using AutoMapper;
using ConversionLogic.ViewModels;
using Core.Models;

namespace ConversionLogic.MappingProfiles
{
    public class ConversionLogicMappingProfile : Profile
    {
        public ConversionLogicMappingProfile()
        {
            CreateMap<CsvViewModel, TransactionDto>()
                .ForMember(d => d.Status, opt => opt.MapFrom(src => (Status)src.Status));

            CreateMap<TransactionViewModel, TransactionDto>()
                .ForMember(d => d.Status, opt => opt.MapFrom(src => (Status)src.Status))
                .ForMember(d => d.Amount, opt => opt.MapFrom(src => src.PaymentDetails.Amount))
                .ForMember(d => d.CurrencyCode, opt => opt.MapFrom(src => src.PaymentDetails.CurrencyCode))
                .ForMember(d => d.TransactionIdentificator, opt => opt.MapFrom(src => src.Id));
        }
    }
}
