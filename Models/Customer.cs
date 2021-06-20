using System;
using System.Collections.Generic;

#nullable disable

namespace Models
    {
    public class Customer
        {
        public Customer()
            {
            Orders = new HashSet<Order>();
            }

        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerUserName { get; set; }
        public string CustomerPassWord { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerStreet { get; set; }
        public string CustomerCityt { get; set; }
        public string CustomerState { get; set; }
        public int CustomerStore { get; set; }

        public virtual LocationDirectory CustomerStoreNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        }
    }
