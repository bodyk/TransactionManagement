using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using TransactionManagement.Validators;

namespace TransactionManagement.Models
{
    public class TransactionFileViewModel
    {
        [Required(ErrorMessage = "Please select a file.")]
        [MaxFileSize(1 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".csv", ".xml" })]
        public IFormFile File { get; set; }
    }
}
