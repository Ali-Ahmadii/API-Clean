using API_Clean.Domain.Entities;
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
        public DbSet<Product> Products { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
