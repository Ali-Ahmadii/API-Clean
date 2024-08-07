using API_Clean.Application.Abstraction;
using API_Clean.Application.Product.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Clean.Application.Product.QueryHandlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProducts, ICollection<API_Clean.Domain.Entities.Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ICollection<Domain.Entities.Product>> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            var pp = await _productRepository.GetAll();
            return pp;
        }
    }
}
