using AutoMapper;
using BusinessLogic.MappingProfiles;
using BusinessLogic.Services;
using ConversionLogic;
using ConversionLogic.FileServices.Abstraction;
using DataAccess.DataContext;
using DataAccess.Repositories;
using DataAccess.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransactionManagement.FileServices.Abstraction;
using TransactionManagement.FileServices.Implementation;

namespace CompositionRoot
{
    public class CompositionRoot
    {
        public CompositionRoot() { }

        public static void InjectDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("Default"));
            });
            services.AddScoped<DatabaseContext>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionService, TransactionService>();


            services.AddScoped<ICsvService, CsvService>();
            services.AddScoped<IXmlService, XmlService>();

            services.AddScoped<TransactionServiceFactory>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
