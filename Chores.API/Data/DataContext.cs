global using Microsoft.EntityFrameworkCore;

using System;
namespace Chores.API.Data
{
	public class DataContext : DbContext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=housechoresdb;" +
                "Trusted_connection=true;TrustServerCertificate=true;");
        }

        public DbSet<HouseChore> Chores { get; set; }
    }
}

