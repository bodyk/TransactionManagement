using ConversionLogic.ViewModels;
using Core.Models;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConversionLogic.FileServices.Abstraction
{
    public interface IService
    {
        Task<List<TransactionDto>> ToTransaction(IFormFile file);
    }
}
