using BusinessLogic.Services;
using DataAccess.DataContext;
using DataAccess.Repositories;
using DataAccess.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompositionRoot
{
    public class CompositionRoot
    {
        public CompositionRoot() { }

        public static void InjectDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("Default"));
            });
            services.AddScoped<DatabaseContext>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
