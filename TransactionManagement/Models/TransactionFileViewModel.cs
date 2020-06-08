using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TransactionManagement.Filters;
using TransactionManagement.Validators;

namespace TransactionManagement.Models
{
    public class TransactionFileViewModel
    {
        [Required(ErrorMessage = "Please select a file.")]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".csv", ".xml" })]
        public IFormFile File { get; set; }
    }
}
