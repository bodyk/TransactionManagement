using ConversionLogic.FileServices.Abstraction;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using TransactionManagement.FileServices.Abstraction;

namespace ConversionLogic
{
    public class TransactionServiceFactory
    {
        private readonly IServiceProvider serviceProvider;

        private readonly string xml = $".xml";
        private readonly string csv = $".csv";

        public TransactionServiceFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IService Create(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            if (extension == csv)
            {
                return (IService)serviceProvider.GetService(typeof(ICsvService));
            }
            else if (extension == xml)
            {
                return (IService)serviceProvider.GetService(typeof(IXmlService));
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
