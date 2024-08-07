using API_Clean.Application.Abstraction;
using API_Clean.Domain.Entities;
using API_Clean.Infrastructure.Context;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Clean.Infrastructure.Repository
{
    
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;
        public ProductRepository(ProductDbContext context)
        {

            _context = context;

        }
        public async Task<Product> AddProduct(Product toCreate)
        {
            _context.Products.Add(toCreate);
            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task DeleteProduct(int ProductId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == ProductId);

            if (product is null) return;

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByUsername(string user)
        {
            API_Clean.Domain.Entities.Product pp = await _context.Products.FirstOrDefaultAsync(x => x.CreatorUsername == user);
            if(pp != null)
            {
                return  pp;
            }
            else
            {
                return null;
            }
        }

        public async Task<Product> GetProductById(int Id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<Product> UpdateProduct(int ProductId, bool IsAvailable)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == ProductId);
            product.IsAvailable = IsAvailable;

            await _context.SaveChangesAsync();

            return product;
        }
    }
}
