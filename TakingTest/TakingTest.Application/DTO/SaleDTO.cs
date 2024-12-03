using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakingTest.Domain.Entities;

namespace TakingTest.Application.DTO
{
    public class SaleDTO : BaseDTO
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
