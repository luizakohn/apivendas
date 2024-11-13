using System.ComponentModel.DataAnnotations;

namespace MyCrudApp.Core.Entities 
{ 
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public DateTime BillingDate { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual List<Item> Items { get; set; } = new List<Item>();
    }
}
