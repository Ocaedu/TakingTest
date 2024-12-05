using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakingTest.Domain.Entities
{
    public class LogEntity : BaseEntity
    {
        [Required]
        [StringLength(250)]
        public DateTime Date { get; set; }

        [Required]
        public string Event { get; set; }
    }
}
