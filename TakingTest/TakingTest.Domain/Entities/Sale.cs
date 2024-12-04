using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace TakingTest.Domain.Entities
{
    public class Sale : BaseEntity
    {
        [Required]
        public Client Client { get; set; }
        [Required]
        public Branch Branch { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public List<SalesProduct> SaleProducts { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public double SalesFinalPrice { get; set; }

    }
}
