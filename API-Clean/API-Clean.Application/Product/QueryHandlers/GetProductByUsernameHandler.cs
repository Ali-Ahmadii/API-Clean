using API_Clean.Application.Abstraction;
using API_Clean.Application.Product.Queries;
using API_Clean.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Clean.Application.Product.QueryHandlers
{
    public class GetProductByUsernameHandler : IRequestHandler<GetProductByUsername, API_Clean.Domain.Entities.Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByUsernameHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Domain.Entities.Product> Handle(GetProductByUsername request, CancellationToken cancellationToken)
        {
            API_Clean.Domain.Entities.Product pp = await _productRepository.GetProductByUsername(request.CreatorUsername);
            return pp;
        }
    }
}
