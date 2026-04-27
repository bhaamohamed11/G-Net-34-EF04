using Bankcom.Configuraions;
using Bankcom.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bankcom
{
    internal class BankDbContext:DbContext
    {
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Manger> Managers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BankSystem;Trusted_Connection=True;TrustServerCertificate=True;");
            

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Account>(new AccountConfiguration());
            modelBuilder.ApplyConfiguration<Branch>(new BranchConfiguration());
            modelBuilder.ApplyConfiguration<Customer>(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration<Manger>(new MangerConfiguration());
            modelBuilder.ApplyConfiguration<Transaction>(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration<CustomerAccount>(new CustomerAccountConfiguration());

            modelBuilder.Entity<Branch>().HasData(
   new Branch { BranchId = 1, BranchCode = "CAI-01", BranchName = "Cairo Main Branch", Address = "10 Tahrir Square, Cairo", PhoneNumber = "0223456789", MangerId = 1 },
new Branch { BranchId = 2, BranchCode = "ALX-01", BranchName = "Alexandria Branch", Address = "55 El-Horreya Road, Alexandria", PhoneNumber = "0345678901", MangerId = 2 },
new Branch { BranchId = 3, BranchCode = "GIZ-01", BranchName = "Giza Branch", Address = "22 Pyramids Road, Giza", PhoneNumber = "0238765432", MangerId = 3 }
    );
            modelBuilder.Entity<Manger>().HasData(
                 new Manger { MangerId = 1, FullName = "Ahmed Hassan", Email = "a.hassan@nationalbank.eg", PhoneNumber = "01001112233", HireDate = new DateTime(2015, 3, 10) },
            new Manger { MangerId = 2, FullName = "Sara Ibrahim", Email = "s.ibrahim@nationalbank.eg", PhoneNumber = "01112223344", HireDate = new DateTime(2017, 7, 1) },
            new Manger { MangerId = 3, FullName = "Omar Mostafa", Email = "o.mostafa@nationalbank.eg", PhoneNumber = "01223334455", HireDate = new DateTime(2019, 1, 15) }


                );

        }
    }
}
