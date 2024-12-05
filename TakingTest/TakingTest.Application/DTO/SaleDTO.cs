using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TakingTest.Domain.Entities;

namespace TakingTest.Application.DTO
{
    public class SaleDTO : BaseDTO
    {
        [Required]
        public long Client { get; set; }
        [Required]
        public long Branch { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public List<SalesProductDTO> SaleProducts { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public double SalesFinalPrice { get; set; }
    }
}
