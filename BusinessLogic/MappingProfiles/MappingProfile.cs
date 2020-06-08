using AutoMapper;
using Core;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TransactionDto, TransactionEntity>()
                .ForMember(d => d.Id, opt => opt.MapFrom(src => src.TransactionIdentificator))
                .ReverseMap();
        }
    }
}
