using System.ComponentModel.DataAnnotations;


namespace PUNX.Domain.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }

    }
}
