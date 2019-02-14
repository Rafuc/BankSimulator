using BankSimulator.API.Models;
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
        public DbSet<TransactionHistory> transactionHistories { get; set; }
        public DbSet<User_Info> UserInfo { get; set; }
        public DbSet<Wealth> Wealths { get; set; }
    }
}
