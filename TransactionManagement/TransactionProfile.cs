using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ConversionLogic.ViewModels;

namespace TransactionManagement
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap(typeof(CsvModel), typeof(Transaction));
        }
    }
}
