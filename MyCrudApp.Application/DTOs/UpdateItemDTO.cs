namespace MyCrudApp.Application.DTOs
{
    public class UpdateItemDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
