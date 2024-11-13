namespace MyCrudApp.Application.DTOs
{
    public class UpdateSaleDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime BillingDate { get; set; }
        public List<UpdateItemDTO> Items { get; set; }
    }
}
