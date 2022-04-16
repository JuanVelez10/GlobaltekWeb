using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tax
    {
        [Required]
        public Guid? Id { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Percentage { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public bool State { get; set; }
    }
}
