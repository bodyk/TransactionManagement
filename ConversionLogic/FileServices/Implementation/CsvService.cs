using AutoMapper;
using ConversionLogic.FileServices.Abstraction;
using ConversionLogic.ViewModels;
using Core;
using CsvHelper;
using CsvHelper.TypeConversion;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionManagement.FileServices.Implementation
{
    public class CsvService : ICsvService
    {
        private readonly IMapper mapper;

        public CsvService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<List<TransactionDto>> ToTransaction(IFormFile file)
        {
            try
            {
                using (var stream = file.OpenReadStream())
                using (var reader = new StreamReader(stream))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.HasHeaderRecord = false;
                    csv.Configuration.RegisterClassMap<CsvTransactionMap>(); 
                    var records = csv.GetRecords<CsvViewModel>().ToList();
                    return Task.FromResult(mapper.Map<List<CsvViewModel>, List<TransactionDto>>(records));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
