using BankSimulator.API.Models;
using BankSimulator.API.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankSimulator.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }
        public DbSet<CreditHistory> CreditHistories { get; set; }
    }
}
