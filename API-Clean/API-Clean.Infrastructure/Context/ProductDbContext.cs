using API_Clean.Domain.Entities;
using Azure.Core;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Clean.Infrastructure.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-4RKBK3P;Initial Catalog=API-Clean;Integrated Security=True;Trust Server Certificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
              new Product { Id = 1,IsAvailable=false,ManufactureEmail = "a@gmail.com",ManufacturePhone="0909",ProduceDate = DateTime.Now,Name = "Dil",CreatorUsername="Ali"},
              new Product { Id = 2, IsAvailable = false, ManufactureEmail = "ab@gmail.com", ManufacturePhone = "0909", ProduceDate = DateTime.Now, Name = "Dil", CreatorUsername = "Alia" }
            );
            builder.Entity<Users>().HasData(
                new Users { Username = "Ali",HashedPassword = BCrypt.Net.BCrypt.HashPassword("Ali")},
                new Users { Username = "Alia", HashedPassword = BCrypt.Net.BCrypt.HashPassword("Alia") }
                );
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
