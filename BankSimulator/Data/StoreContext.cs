using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankSimulator.Model
{
    class StoreContext : DbContext
    {
        public DbSet<Account> Account { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=BankSimulator;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
