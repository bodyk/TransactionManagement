using ConversionLogic.FileServices.Abstraction;
using ConversionLogic.FileServices.Implementation;
using ConversionLogic.ViewModels;
using Core;
using DataAccess.Entities;
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
        public XmlService()
        {
            this.serializer = new Serializer();
        }

        public async Task<List<TransactionDto>> ToTransaction(IFormFile file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<TransactionViewModel>), new XmlRootAttribute("Transactions"));
            var xmlString = await ReadAsStringAsync(file);
            StringReader stringReader = new StringReader(xmlString);
            var result = (List<TransactionViewModel>)serializer.Deserialize(stringReader);

            List<TransactionDto> entities = new List<TransactionDto>();

            foreach (var item in result)
            {
                var tr = new TransactionDto
                {
                    Amount = item.PaymentDetails.Amount,
                    CurrencyCode = item.PaymentDetails.CurrencyCode,
                    TransactionIdentificator = item.Id,
                    Status = (Status)item.Status,
                    TransactionDate = item.TransactionDate
                };
                entities.Add(tr);
            }

            return entities;
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
