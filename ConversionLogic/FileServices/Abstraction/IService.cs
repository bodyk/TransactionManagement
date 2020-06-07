using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Transactions;

namespace ConversionLogic.FileServices.Abstraction
{
    public interface IService
    {
        IEnumerable<Transaction> ToTransaction(IFormFile file);
    }
}
