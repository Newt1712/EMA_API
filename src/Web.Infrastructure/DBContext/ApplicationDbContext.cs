using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Application.Interfaces.Repositories.Base;
using Web.Domain.Entities;
using MediatR;

namespace Web.Infrastructure.DBContext
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<SampleEntity> SampleEntities { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

    #region To able to run "dotnet ef migrations"

    /// <summary>
    /// To able to use dotnet migrations, the value of connection string is not matter
    /// </summary>
    public class ApplicationContextDesignFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseNpgsql("Server=localhost;Port=5432;Database=austitic_children;Username=postgres;Password=123;IncludeErrorDetail=true");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }

    #endregion
}
