using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TakingTest.Application.DTO;

namespace TakingTest.Domain.Entities
{
    public class SalesProductDTO : BaseDTO
    {
        [JsonIgnore]
        [IgnoreDataMember]
        public long IdSale { get; set; }
        [Required]
        public long IdProduct { get; set; }
        [Required]
        public long Quantity { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public bool Canceled { get; set; }
    }
}
