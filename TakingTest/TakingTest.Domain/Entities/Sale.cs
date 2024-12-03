using System.ComponentModel.DataAnnotations;

namespace TakingTest.Domain.Entities
{
    public class Sale : BaseEntity
    {
        [Required]
        public Client Client { get; set; }
        [Required]
        public Branch Branch { get; set; }
        [Required]
        public long Discount { get; set; }
        [Required]
        public long SalesFinalPrice { get; set; }
        [Required]
        public List<Product> Products { get; set; }
    }
}
