using AutoMapper;
using ConversionLogic.FileServices.Abstraction;
using ConversionLogic.ViewModels;
using CsvHelper;
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
}
