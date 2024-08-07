using API_Clean.Application.Abstraction;
using API_Clean.Application.Product.Command;
using API_Clean.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Clean.Application.Product.CommandHandlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProduct, API_Clean.Domain.Entities.Product>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Domain.Entities.Product> Handle(DeleteProduct request, CancellationToken cancellationToken)
        {

            API_Clean.Domain.Entities.Product product = await _productRepository.GetProductById(request.Id);
            if (product is null) 
                return null;
            if(request.CreatorUsername == product.CreatorUsername)
                await _productRepository.DeleteProduct(request.Id);
                return  product;
            return null;

        }
    }
}
