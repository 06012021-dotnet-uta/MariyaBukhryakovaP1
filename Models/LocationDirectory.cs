using System;
using System.Collections.Generic;

#nullable disable

namespace Models
    {
    public class LocationDirectory
        {
        public LocationDirectory()
            {
            Customers = new HashSet<Customer>();
            Stores = new HashSet<Store>();
            }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public long? StorePhone { get; set; }
        public string StoreStreetAd { get; set; }
        public string StoreCitytAd { get; set; }
        public string StoreStateAd { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
        }
    }
