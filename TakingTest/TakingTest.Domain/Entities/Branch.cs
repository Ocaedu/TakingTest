﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakingTest.Domain.Entities
{
    public class Branch : BaseEntity
    {
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
    }
}
