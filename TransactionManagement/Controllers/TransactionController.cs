using BusinessLogic.Services;
using ConversionLogic.FileServices.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TransactionManagement.FileServices.Abstraction;

namespace TransactionManagement.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly IXmlService xmlService;
        private readonly ICsvService csvService;
        private readonly ITransactionService transactionService;

        public TransactionController(
            ITransactionService transactionService, 
            ILogger<TransactionController> logger,
            IXmlService xmlService,
            ICsvService csvService)
        {
            this.transactionService = transactionService;
            _logger = logger;
            this.xmlService = xmlService;
            this.csvService = csvService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> File(IFormFile file)
        {
            var results = await xmlService.ToTransaction(file);
            return RedirectToAction("Index");
        }
    }
}
