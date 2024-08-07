using API_Clean.Application.Abstraction;
using API_Clean.Application.Product.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Clean.Application.Product.CommandHandlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProduct, API_Clean.Domain.Entities.Product>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Domain.Entities.Product> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {

            API_Clean.Domain.Entities.Product product = await _productRepository.GetProductById(request.Id);
            if (product is null)
                return null;
            if (request.CreatorUsername == product.CreatorUsername)
                return await _productRepository.UpdateProduct(request.Id, request.IsAvailable);
            return null;
        }
    }
}
