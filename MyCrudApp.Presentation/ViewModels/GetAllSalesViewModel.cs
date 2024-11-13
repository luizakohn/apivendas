namespace MyCrudApp.Presentation.ViewModels
{
    public class GetAllSalesViewModel
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public DateTime BillingDate { get; set; }
        public string CustomerName { get; set; }
        public double TotalPrice { get; set; }
        public int TotalItems { get; set; }
    }
}
