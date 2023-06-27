using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace AccountOwnerServer.DBContext
{
    public class DBInteractor : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlite(@"Data Source = Students.db;");
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Owner> Owner { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var owner1 = new Owner() { Name = "George Smith", DateOfBirth = DateTime.Now.AddYears(-25), Accounts = null, Address = "1234 Paved Road Kingston, Ontario K0H 1X0", Id = Guid.NewGuid() };
            var owner2 = new Owner() { Name = "Dave jones", DateOfBirth = DateTime.Now.AddYears(-43), Accounts = null, Address = "1234 Gravel Road Kingston, Ontario K0H 1J0", Id = Guid.NewGuid() };

            modelBuilder.Entity<Owner>().HasData(owner1, owner2);

            var account1 = new Account() { Id = Guid.NewGuid(), AccountType = "Admin", DateCreated = DateTime.Now, OwnerId = owner1.Id };
            var account2 = new Account() { Id = Guid.NewGuid(), AccountType = "User", DateCreated = DateTime.Now, OwnerId = owner2.Id };

            modelBuilder.Entity<Account>().HasData(account1,account2);

        }
    }
}
