
using System.ComponentModel.DataAnnotations;

namespace TakingTest.Domain.Entities
{
    public class Client : BaseEntity
    {
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
    }
}
