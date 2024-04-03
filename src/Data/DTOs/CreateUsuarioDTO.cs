using System.ComponentModel.DataAnnotations;

namespace Identity6.Data.DTOs
{
    public class CreateUsuarioDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
