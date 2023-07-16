using Chores.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Chores.Data;

public class DataContext : DbContext
{
    public DbSet<HouseChore> Chores { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}
	    
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
		optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=housechoresdb;Integrated Security=True;Trusted_connection=true;TrustServerCertificate=true;");
	}
}