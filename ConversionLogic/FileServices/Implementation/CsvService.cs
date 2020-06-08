using AutoMapper;
using ConversionLogic.FileServices.Abstraction;
using ConversionLogic.ViewModels;
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

        public Task<IEnumerable<CsvModel>> ToTransaction(IFormFile file)
        {
            if (file == null)
                return Task.FromResult(Enumerable.Empty<CsvModel>());

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
                    var records = csv.GetRecords<CsvModel>().ToList();
                    return Task.FromResult(records.AsEnumerable());
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

    public class FooMap : ClassMap<CsvModel>
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
