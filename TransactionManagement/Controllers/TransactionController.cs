using BusinessLogic.Services;
using ConversionLogic.FileServices.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TransactionManagement.FileServices.Abstraction;

namespace TransactionManagement.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ICsvService csvService;
        private readonly ITransactionService transactionService;

        public TransactionController(
            ITransactionService transactionService, 
            ILogger<TransactionController> logger,
            ICsvService csvService)
        {
            this.transactionService = transactionService;
            _logger = logger;
            this.csvService = csvService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult File(IFormFile file)
        {
            var results = csvService.ToTransaction(file);
            return RedirectToAction("Index");
        }
    }
}
