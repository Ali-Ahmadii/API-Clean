using API_Clean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Clean.Application.Abstraction
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetAll();

        Task<Product> GetProductById(int ProductId);

        Task<Product> AddProduct(Product toCreate);

        Task<Product> UpdateProduct(int ProductId, string Name, Boolean IsAvailable);

        Task DeleteProduct(int ProductId);
    }
}
