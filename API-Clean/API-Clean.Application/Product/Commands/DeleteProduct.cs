using API_Clean.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Clean.Application.Product.Command
{
    public class DeleteProduct : IRequest<API_Clean.Domain.Entities.Product>
    {
        public int Id { get; set; }
    }
}
