using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        [Required]
        public Guid? Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public bool State { get; set; }
    }
}
