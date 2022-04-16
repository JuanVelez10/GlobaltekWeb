using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class BillBasic
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
        public Guid? PersonId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        [DataType(DataType.Text)]
        public string? NameClient { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }
    }
}
