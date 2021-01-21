using System.ComponentModel.DataAnnotations;

namespace models.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(40, MinimumLength=4)]
        public string Password { get; set; }
    }
}