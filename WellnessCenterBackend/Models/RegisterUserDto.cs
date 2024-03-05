using System.ComponentModel.DataAnnotations;

namespace WellnessCenterBackend.Models
{
    public class RegisterUserDto
    {
        [Required]
        public string Login { get; set; }
        [Required]
        [MinLength(5)]
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId {  get; set; }
    }
}
