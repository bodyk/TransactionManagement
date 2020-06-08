using BusinessLogic.Services;
using ConversionLogic.FileServices.Abstraction;
using DataAccess.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionManagement.Commands;
using TransactionManagement.FileServices.Abstraction;
using TransactionManagement.Filters;
using TransactionManagement.Models;
using TransactionManagement.Queries;

namespace TransactionManagement.Queries
{
    public class TransactionController : Controller
    {
        private readonly IMediator mediator;

        public TransactionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ModelStateValidationAttribute]
        public async Task<IActionResult> File(TransactionFileViewModel fileViewModel)
        {
            var command = new UploadTransactionsCommand(fileViewModel);
            var result = await mediator.Send(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactionsByCurrency(string currency)
        {
            var query = new GetTransactionsByCurrencyQuery(currency);
            var result = await mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactionsByDateRange(DateTime startDate, DateTime endDate)
        {
            var query = new GetTransactionsByDateRangeQuery(startDate, endDate);
            var result = await mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactionsByStatus(string status)
        {
            var query = new GetTransactionsByStatusQuery(status);
            var result = await mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
    }
}
