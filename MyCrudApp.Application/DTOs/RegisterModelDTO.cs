using System.ComponentModel.DataAnnotations;

namespace MyCrudApp.Application.DTOs
{
    public class RegisterModelDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string ImageLink { get; set; }
    }
}
