using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TakingTest.Domain.Entities
{
    public class SalesProduct
    {
        private decimal value;

        public long SaleId { get; set; }
        public Sale Sale { get; set; }
        [Required]
        public long ProductId { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        public long Quantity { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public bool Canceled { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public decimal Value
        {
            get
            {
                value = (Product.Price - (Product.Price  * Discount)) * Quantity;
                return value;
            }
        }
    }
}
