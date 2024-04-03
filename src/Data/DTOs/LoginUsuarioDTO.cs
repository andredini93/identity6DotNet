using System.ComponentModel.DataAnnotations;

namespace Identity6.Data.DTOs
{
    public class LoginUsuarioDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
