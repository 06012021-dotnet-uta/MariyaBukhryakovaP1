using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
    {
    interface IitemsInOrder
        {
        public int OrderId1 { get; set; }
        public int OrderStoreId { get; set; }
        public int OrderProductId { get; set; }
        public int? OrderProductQantity { get; set; }

        }
    }
