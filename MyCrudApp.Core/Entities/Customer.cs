using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyCrudApp.Core.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        [JsonIgnore]
        public bool IsActive { get; set; } = true;
        [JsonIgnore]
        public virtual List<Sale> Sales { get; set; } = new List<Sale>();
    }
}
