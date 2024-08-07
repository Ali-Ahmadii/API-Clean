using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Clean.Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Boolean IsAvailable { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string ManufactureEmail { get; set;}

        [Required]
        public string ManufacturePhone { get; set;}
        [Required]
        public DateTime ProduceDate { get; set; } = DateTime.Now;
        [Required]
        public string Name { get; set; }
        public string CreatorUsername { get; set; }
    }
}
