using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Infrastructure.DBContext;
using Web.Infrastructure.Interfaces;
using Web.Infrastructure.Services;

namespace Web.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabasePersistence(configuration);
            services.AddRepositories();

            services.AddBackgroundServices(configuration);

        }

        private static void AddDatabasePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseNpgsql(configuration.GetConnectionString("ApplicationConnection"), o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

            services.AddScoped<IDbInitializeService, DbInitializeService>();
        }

        private static void AddBackgroundServices(this IServiceCollection services, IConfiguration configuration)
        {
        }

        private static void AddRepositories(this IServiceCollection services)
        {
        }

    }
}
