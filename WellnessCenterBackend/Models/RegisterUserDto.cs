using System.ComponentModel.DataAnnotations;

namespace WellnessCenterBackend.Models
{
    public class RegisterUserDto
    {
        [Required]
        [MinLength(5)]
        public string Login { get; set; }

        [Required]
        [MinLength(5)]
        public string Password { get; set; }
        [Required]
        [MinLength(5)]
        public string RepeatPassword { get; set; }
    }
}
