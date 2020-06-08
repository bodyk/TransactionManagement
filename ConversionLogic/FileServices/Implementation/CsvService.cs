using AutoMapper;
using ConversionLogic.FileServices.Abstraction;
using ConversionLogic.ViewModels;
using Core;
using CsvHelper;
using CsvHelper.Configuration;
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
                    csv.Configuration.Delimiter = ",";
                    csv.Configuration.IgnoreQuotes = true;
                    csv.Configuration.RegisterClassMap<FooMap>(); 
                    var records = csv.GetRecords<CsvViewModel>().ToList();

                    List<TransactionDto> entities = new List<TransactionDto>();
                    foreach (var item in records)
                    {
                        var tr = new TransactionDto
                        {
                            Amount = item.Amount,
                            CurrencyCode = item.CurrencyCode,
                            TransactionIdentificator = item.TransactionIdentificator,
                            Status = (Status)item.Status,
                            TransactionDate = item.TransactionDate
                        };
                        entities.Add(tr);
                    }
                    return Task.FromResult(entities);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

    public class FooMap : ClassMap<CsvViewModel>
    {
        public FooMap()
        {
            Map(m => m.TransactionIdentificator);
            Map(m => m.Amount);
            Map(m => m.CurrencyCode);
            Map(m => m.TransactionDate).TypeConverterOption.Format("dd/MM/yyyy hh:mm:ss");
            Map(m => m.Status);
        }
    }

    public class FormattedDecimalTypeConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            var txt = text.Replace(",", "");
            return txt;
        }
    }
}
