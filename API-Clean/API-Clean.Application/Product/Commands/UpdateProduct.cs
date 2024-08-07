using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Clean.Application.Product.Command
{
    public class UpdateProduct : IRequest<API_Clean.Domain.Entities.Product>
    {
        public int Id { get; set; }
        public Boolean IsAvailable { get; set; }
        public string CreatorUsername { get; set; }
    }
}
