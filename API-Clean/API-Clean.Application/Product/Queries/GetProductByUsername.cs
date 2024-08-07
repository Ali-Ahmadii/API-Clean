using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Clean.Application.Product.Queries
{
    public class GetProductByUsername : IRequest<API_Clean.Domain.Entities.Product>
    {
        public string CreatorUsername { get; set; }
    }
}
