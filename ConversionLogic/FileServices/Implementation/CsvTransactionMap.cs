using ConversionLogic.ViewModels;
using CsvHelper.Configuration;

namespace TransactionManagement.FileServices.Implementation
{
    public class CsvTransactionMap : ClassMap<CsvViewModel>
    {
        public CsvTransactionMap()
        {
            Map(m => m.TransactionIdentificator);
            Map(m => m.Amount);
            Map(m => m.CurrencyCode);
            Map(m => m.TransactionDate).TypeConverterOption.Format("dd/MM/yyyy hh:mm:ss");
            Map(m => m.Status);
        }
    }
}
