using API_Clean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Clean.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Clean.Application.Abstraction
{
    public interface IProductRepository
    {
        Task<ICollection<API_Clean.Domain.Entities.Product>> GetAll();

        Task<API_Clean.Domain.Entities.Product> GetProductByUsername(string user);

        Task<API_Clean.Domain.Entities.Product> AddProduct(API_Clean.Domain.Entities.Product toCreate);

        Task<API_Clean.Domain.Entities.Product> GetProductById(int Id);

        Task DeleteProduct(int ProductId);
        Task<API_Clean.Domain.Entities.Product> UpdateProduct(int ProductId, bool IsAvailable);
    }
}
