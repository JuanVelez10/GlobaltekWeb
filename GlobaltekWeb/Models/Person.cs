using System.ComponentModel.DataAnnotations;
using static Web.Models.Enums;

namespace Web.Models
{
    public class Person
    {
        [Required]
        public Guid? Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 10)]
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        [DataType(DataType.Text)]
        public string? Document { get; set; }

        [Required]
        [Phone]
        public string? Phone { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }

        [Required]
        public RoleType RoleType { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Create { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Update { get; set; }

    }
}
