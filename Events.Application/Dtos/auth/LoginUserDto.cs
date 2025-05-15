using System.ComponentModel.DataAnnotations;

namespace Events.Application.Dtos.auth
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; } = default!;
    }
}
