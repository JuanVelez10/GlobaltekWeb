using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums.Enums;

namespace Domain.Dtos
{
    public class BillInfo
    {

        [Required]
        public Guid? Id { get; set; }

        [Required]
        [RegularExpression("[0-9]*", ErrorMessage = "Only numeric value")]
        public int Number { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal SubTotal { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal DiscountTotal { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal TaxTotal { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        [Required]
        public Guid? PersonId { get; set; }

        [Required]
        public Guid? TaxId { get; set; }

        [Required]
        public Guid? DiscountId { get; set; }

        public string NamePerson { get; set; }
        public string DocumenPerson { get; set; }
        public Tax? Tax { get; set; }
        public Discount? Discount { get; set; }
        public ICollection<BillDetailInfo>? BillDetails { get; set; }
    }
}
