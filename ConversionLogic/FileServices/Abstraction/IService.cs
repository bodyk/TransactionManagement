using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConversionLogic.FileServices.Abstraction
{
    public interface IService
    {
        Task<IEnumerable<Transaction>> ToTransaction(IFormFile file);
    }
}
