using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
    {
    interface IStore
        {
        public int StoreLocation { get; set; }
        public int StoreProduct { get; set; }
        public int ProductInventory { get; set; }
        }
    }
