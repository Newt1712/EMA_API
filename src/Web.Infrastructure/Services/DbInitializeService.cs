using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Infrastructure.DBContext;
using Web.Infrastructure.Interfaces;

namespace Web.Infrastructure.Services
{
    public class DbInitializeService : IDbInitializeService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public DbInitializeService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void Migrate()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
        }

        public void Seed()
        {
            Task.WaitAll();
        }
    }
}
