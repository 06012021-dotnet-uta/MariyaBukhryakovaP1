using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
    {
    interface IOrders
        {
        public int OrderId { get;  }
        public int OrderAccountId { get; set; }
        public int OrderStoreId { get; set; }
       
        }
    }
