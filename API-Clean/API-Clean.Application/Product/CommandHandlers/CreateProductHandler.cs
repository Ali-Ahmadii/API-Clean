using API_Clean.Application.Abstraction;
using API_Clean.Application.Product.Command;
using API_Clean.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Clean.Application.Product.CommandHandlers
{
    public class CreateProductHandler : IRequestHandler<CreateProduct, API_Clean.Domain.Entities.Product>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Domain.Entities.Product> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            var product = new API_Clean.Domain.Entities.Product
            {
                Name = request.Name,
                IsAvailable = request.IsAvailable,
                ManufactureEmail = request.ManufactureEmail,
                ManufacturePhone = request.ManufacturePhone,
                ProduceDate = request.ProduceDate,
                CreatorUsername = request.CreatorUsername
            };

            return await _productRepository.AddProduct(product);
        }
    }
}
