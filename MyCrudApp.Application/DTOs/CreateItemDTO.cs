using System.ComponentModel.DataAnnotations;

namespace MyCrudApp.Application.DTOs
{
    public class CreateItemDTO
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
