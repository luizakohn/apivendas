using MyCrudApp.Core.Entities;

namespace MyCrudApp.Presentation.ViewModels
{
    public class GetSalesByIdViewModel
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime BillingDate { get; set; }
        public List<Item> Items { get; set; }
    }
}
