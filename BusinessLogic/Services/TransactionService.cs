using AutoMapper;
using Core;
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

        public async Task<List<TransactionDto>> GetAllByCurrency(string currency)
        {
            var results = await unitOfWork.TransactionRepository.GetAllByCurrency(currency);
            return mapper.Map<List<TransactionEntity>, List<TransactionDto>>(results);
        }

        public async Task<List<TransactionDto>> GetAllByDateRange(DateTime startDate, DateTime endDate)
        {
            var results = await unitOfWork.TransactionRepository.GetAllByDateRange(startDate, endDate);
            return mapper.Map<List<TransactionEntity>, List<TransactionDto>>(results);

        }

        public async Task<List<TransactionDto>> GetAllByStatus(string status)
        {
            Status st = (Status)Enum.Parse(typeof(Status), status);
            var results = await unitOfWork.TransactionRepository.GetAllByStatus(st);
            return mapper.Map<List<TransactionEntity>, List<TransactionDto>>(results);
        }

        public Task UpploadAsync(List<TransactionDto> transactions)
        {
            var transactionsToUpload = mapper.Map<List<TransactionDto>, List<TransactionEntity>>(transactions);
            unitOfWork.TransactionRepository.Uppload(transactionsToUpload);
            return unitOfWork.CommitAsync();
        }
    }
}
