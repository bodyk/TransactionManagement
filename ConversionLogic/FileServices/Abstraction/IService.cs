using Core.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConversionLogic.FileServices.Abstraction
{
    public interface IService
    {
        Task<List<TransactionDto>> ToTransaction(IFormFile file);
    }
}
