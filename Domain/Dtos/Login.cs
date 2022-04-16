using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class Login
    {
        [Required]
        [DataType(DataType.Text)]
        public string? Token { get; set; }

        [Required]
        public Person? person { get; set; }
    }
}
