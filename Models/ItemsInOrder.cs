using System;
using System.Collections.Generic;

#nullable disable

namespace Models
    {
    public class ItemsInOrder : IitemsInOrder
        {
        public int OrderId1 { get; set; }
        public int OrderStoreId { get; set; }
        public int OrderProductId { get; set; }
        public int? OrderProductQantity { get; set; }

        public virtual Store Order { get; set; }
        public virtual Order OrderId1Navigation { get; set; }
        }
    }
