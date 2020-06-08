using ConversionLogic.FileServices.Implementation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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

        public async Task<IEnumerable<Transaction>> ToTransaction(IFormFile file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Transaction>), new XmlRootAttribute("Transactions"));
            var xmlString = await ReadAsStringAsync(file);
            StringReader stringReader = new StringReader(xmlString);
            var result = (List<Transaction>)serializer.Deserialize(stringReader);

            return result;
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
