using AutoMapper;
using BusinessLogic.MappingProfiles.Converters;
using Core.Models;
using DataAccess.Entities;

namespace BusinessLogic.MappingProfiles
{
    public class BusinessLogicMappingProfile : Profile
    {
        public BusinessLogicMappingProfile()
        {
            CreateMap<TransactionDto, TransactionEntity>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.TransactionIdentificator))
                .ReverseMap();

            CreateMap<TransactionEntity, TransactionResult>()
                .ConvertUsing<TransactionEntityToResultConverter>();
        }
    }
}
