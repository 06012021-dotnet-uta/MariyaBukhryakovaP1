using System;
using System.Collections.Generic;

#nullable disable

namespace Models
    {
    public partial class Order
        {
        public int OrderId { get; set; }
        public int OrderAccountId { get; set; }
        public int OrderStoreId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Customer OrderNavigation { get; set; }
        }
    }
