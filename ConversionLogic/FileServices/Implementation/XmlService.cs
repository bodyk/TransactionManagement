using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Transactions;
using TransactionManagement.FileServices.Abstraction;

namespace TransactionManagement.FileServices.Implementation
{
    public class XmlService : IXmlService
    {
        public IEnumerable<Transaction> ToTransaction(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
