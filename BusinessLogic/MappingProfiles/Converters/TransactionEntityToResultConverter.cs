using AutoMapper;
using Core;
using DataAccess.Entities;
using System.Linq;

namespace BusinessLogic.MappingProfiles.Converters
{
    public class TransactionEntityToResultConverter : ITypeConverter<TransactionEntity, TransactionResult>
    {
        public TransactionResult Convert(TransactionEntity source, TransactionResult destination, ResolutionContext context)
        {
            return new TransactionResult
            {
                Id = source.Id,
                Payment = $"{source.Amount} {source.CurrencyCode}",
                Status = source.Status.ToString().FirstOrDefault()
            };
        }
    }
}
