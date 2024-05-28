using CosmosMinimalApi.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace CosmosMinimalApi.Api.Data
{
    public class CustomerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                "",//URI
                "",//Primary key
                "");//Database name
        }

        public virtual DbSet<Customer> Customers { get; set; }

        //Här görs en koppling mellan rätt container och listan
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToContainer("Customers").HasPartitionKey(s => s.Id);
        }
    }
}
