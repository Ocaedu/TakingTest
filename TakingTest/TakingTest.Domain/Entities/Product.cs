﻿
using System.ComponentModel.DataAnnotations;


namespace TakingTest.Domain.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
