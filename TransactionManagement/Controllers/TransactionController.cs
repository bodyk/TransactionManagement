using BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TransactionManagement.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ILogger<TransactionController> _logger;

        private readonly ITransactionService transactionService;

        public TransactionController(ITransactionService transactionService, ILogger<TransactionController> logger)
        {
            this.transactionService = transactionService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult File(IFormFile file)
        {
            return RedirectToAction("Index");
        }
    }
}
