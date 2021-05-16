using Macoratti.RepositoryPattern.Api.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Macoratti.RepositoryPattern.Api.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        { }

        public AppDbContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Password=superuser;Persist Security Info=True;User ID=sa;Initial Catalog=MacorattiRepositoryPattern;Data Source=LAPTOP-R6D0M2P1");
        }
    }
}
