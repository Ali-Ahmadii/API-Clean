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
            return await _productRepository.UpdateProduct(request.Id, request.IsAvailable);
        }
    }
}
