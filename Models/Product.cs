using System;
using System.Collections.Generic;

#nullable disable

namespace Models
    {
    public class Product
        {
        public Product()
            {
            Stores = new HashSet<Store>();
            }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string Department { get; set; }

        public virtual ICollection<Store> Stores { get; set; }
        }
    }
