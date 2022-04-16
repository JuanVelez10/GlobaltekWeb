using System.ComponentModel.DataAnnotations;

namespace Web.Models
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
