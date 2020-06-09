using AutoMapper;
using Core.Models;
using DataAccess.Entities;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<TransactionResult>> GetAllByCurrency(string currency)
        {
            var results = await unitOfWork.TransactionRepository.GetAllByCurrency(currency);
            return mapper.Map<List<TransactionEntity>, List<TransactionResult>>(results);
        }

        public async Task<List<TransactionResult>> GetAllByDateRange(DateTime startDate, DateTime endDate)
        {
            var results = await unitOfWork.TransactionRepository.GetAllByDateRange(startDate, endDate);
            return mapper.Map<List<TransactionEntity>, List<TransactionResult>>(results);

        }

        public async Task<List<TransactionResult>> GetAllByStatus(string status)
        {
            Status st = (Status)Enum.Parse(typeof(Status), status);
            var results = await unitOfWork.TransactionRepository.GetAllByStatus(st);
            return mapper.Map<List<TransactionEntity>, List<TransactionResult>>(results);
        }

        public Task<int> UpploadAsync(List<TransactionDto> transactions)
        {
            var transactionsToUpload = mapper.Map<List<TransactionDto>, List<TransactionEntity>>(transactions);
            unitOfWork.TransactionRepository.Uppload(transactionsToUpload);
            return unitOfWork.CommitAsync();
        }
    }
}
