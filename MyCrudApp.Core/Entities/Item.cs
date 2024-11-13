using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyCrudApp.Core.Entities 
{ 
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Quantity { get; set; }
        [JsonIgnore]
        public int SaleId { get; set; }
        [JsonIgnore]
        public virtual Sale? Sale { get; set; }
    }
}
