using BusinessLogic.Services;
using ConversionLogic.FileServices.Abstraction;
using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionManagement.FileServices.Abstraction;
using TransactionManagement.Filters;
using TransactionManagement.Models;

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

        public async Task<IActionResult> File(TransactionFileViewModel fileViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            if (fileViewModel != null)
            {
                var file = fileViewModel.File;
                if (file == null)
                    return RedirectToAction("Index");

                List<TransactionEntity> entities = new List<TransactionEntity>();
                if (file.FileName.EndsWith("csv"))
                {
                    var res = await csvService.ToTransaction(file);
                    foreach (var item in res)
                    {
                        var tr = new TransactionEntity
                        {
                            Amount = item.Amount,
                            CurrencyCode = item.CurrencyCode.ToString(),
                            Id = item.TransactionIdentificator,
                            Status = (Status)item.Status,
                            TransactionDate = item.TransactionDate
                        };
                        entities.Add(tr);
                    }
                }
                else if (file.FileName.EndsWith("xml"))
                {
                    var res = await xmlService.ToTransaction(file);
                    foreach (var item in res)
                    {
                        var tr = new TransactionEntity
                        {
                            Amount = item.PaymentDetails.Amount,
                            CurrencyCode = item.PaymentDetails.CurrencyCode,
                            Id = item.Id,
                            Status = (Status)item.Status,
                            TransactionDate = item.TransactionDate
                        };
                        entities.Add(tr);
                    }
                }
                await transactionService.UpploadAsync(entities);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactionsByCurrency(string currency)
        {
            return Ok(await transactionService.GetAllByCurrency(currency));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactionsByDateRange(DateTime startDate, DateTime endDate)
        {
            return Ok(await transactionService.GetAllByDateRange(startDate, endDate));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactionsByStatus(string status)
        {
            return Ok(await transactionService.GetAllByStatus(status));
        }
    }
}
