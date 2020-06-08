using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConversionLogic.FileServices.Abstraction
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> ToTransaction(IFormFile file);
    }
}
