using System.ComponentModel.DataAnnotations;

namespace MyCrudApp.Application.DTOs
{
    public class CreateSaleDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int CustomerId { get; set; }
        [Required]
        public DateTime BillingDate { get; set; }
        [Required]
        public List<CreateItemDTO> Items { get; set; } = new List<CreateItemDTO>();
    }
}
