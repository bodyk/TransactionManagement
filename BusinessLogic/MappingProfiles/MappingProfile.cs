using AutoMapper;
using BusinessLogic.MappingProfiles.Converters;
using Core;
using DataAccess.Entities;

namespace BusinessLogic.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TransactionDto, TransactionEntity>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.TransactionIdentificator))
                .ReverseMap();

            CreateMap<TransactionEntity, TransactionResult>()
                .ConvertUsing<TransactionEntityToResultConverter>();
        }
    }
}
