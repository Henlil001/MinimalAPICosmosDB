using CosmosMinimalApi.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace CosmosMinimalApi.Api.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext()
        {
           
        }

        public virtual DbSet<Customer> Customers { get; set; }

        //Här görs en koppling mellan rätt container och listan
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToContainer("Students").HasPartitionKey(s => s.Id);
        }
    }
}
