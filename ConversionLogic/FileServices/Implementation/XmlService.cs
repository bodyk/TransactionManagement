using AutoMapper;
using ConversionLogic.FileServices.Implementation;
using ConversionLogic.ViewModels;
using Core.Exceptions;
using Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TransactionManagement.FileServices.Abstraction;

namespace TransactionManagement.FileServices.Implementation
{
    public class XmlService : IXmlService
    {
        private readonly Serializer serializer;
        private readonly IMapper mapper;

        public XmlService(IMapper mapper)
        {
            this.serializer = new Serializer();
            this.mapper = mapper;
        }

        public async Task<List<TransactionDto>> ToTransaction(IFormFile file)
        {
            List<TransactionViewModel> records = new List<TransactionViewModel>();
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<TransactionViewModel>), new XmlRootAttribute("Transactions"));
                var xmlString = await ReadAsStringAsync(file);
                StringReader stringReader = new StringReader(xmlString);
                records = (List<TransactionViewModel>)serializer.Deserialize(stringReader);
            }
            catch (Exception ex)
            {
                throw new TransactionValidationException(ex);
            }
            
            return mapper.Map<List<TransactionViewModel>, List<TransactionDto>>(records);
        }

        public async Task<string> ReadAsStringAsync(IFormFile file)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(await reader.ReadLineAsync());
            }
            return result.ToString();
        }
    }
}
