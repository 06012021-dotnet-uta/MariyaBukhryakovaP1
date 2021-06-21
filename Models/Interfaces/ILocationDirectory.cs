using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
    {
    interface ILocationDirectory
        {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public long? StorePhone { get; set; }
        public string StoreStreetAd { get; set; }
        public string StoreCitytAd { get; set; }
        public string StoreStateAd { get; set; }
        }
    }
