using System.ComponentModel.DataAnnotations;

namespace MyCrudApp.Application.DTOs
{
    public class CreateCustomerDTO
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;
        [Required]
        [MaxLength(18)]
        public string Cpf { get; set; } = string.Empty;
    }
}