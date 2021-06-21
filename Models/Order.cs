using System;
using System.Collections.Generic;

#nullable disable

namespace Models
    {
    public class Order : IOrders
        {
        public int OrderId { get;  }
        public int OrderAccountId { get; set; }
        public int OrderStoreId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Customer OrderNavigation { get; set; }
        }
    }
