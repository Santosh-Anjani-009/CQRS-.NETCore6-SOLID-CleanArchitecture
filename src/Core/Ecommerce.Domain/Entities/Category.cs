﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Entities
{
    public class Category: BaseEntity<int>
    {
        public Category(string name, string description)
        {
            Name = name; 
            Description = description; 
        }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigational Property
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
