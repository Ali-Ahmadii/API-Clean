using API_Clean.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API_Clean.Application.Product.Command
{
    public class CreateProduct : IRequest<API_Clean.Domain.Entities.Product>
    {
        public Boolean IsAvailable { get; set; }
        public string ManufactureEmail { get; set; }
        public string ManufacturePhone { get; set; }
        public DateTime ProduceDate { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public string CreatorUsername { get; set; }
    }
}
