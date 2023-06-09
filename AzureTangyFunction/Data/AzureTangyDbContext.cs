using AzureTangyFunction.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureTangyFunction.Data
{
    public class AzureTangyDbContext : DbContext
    {

        // In order to use EF, Implementing dependency injection to dbcontext constructor
        public AzureTangyDbContext(DbContextOptions<AzureTangyDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        //Exposing a property called "SalesRequests" that allows you to interact with the collection of "SalesRequest" entities in the associated database context.
        //This property provides access to various methods and properties for querying, inserting, updating, and deleting entities in the "SalesRequests" table of the underlying database.
        public DbSet<SalesRequest> SalesRequests { get; set; }

        // Overriding to set changes on the table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configuring the SalesRequest entity's primary key to be the "Id" property
            modelBuilder.Entity<SalesRequest>(entity => { entity.HasKey(c => c.Id); });
        }
    }
}
