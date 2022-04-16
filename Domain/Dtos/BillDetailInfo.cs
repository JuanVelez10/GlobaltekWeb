using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class BillDetailInfo
    {
        [Required]
        public Guid? Id { get; set; }

        [Required]
        public Guid? ProductId { get; set; }

        [Required]
        public string? NameProduct { get; set; }

        [Required]
        [RegularExpression("[0-9]*", ErrorMessage = "Only numeric value")]
        public int Amount { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal UnitCost { get; set; }

        [Required]
        public Guid? BillId { get; set; }
    }
}
