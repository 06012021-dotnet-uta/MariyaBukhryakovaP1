using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Models
    {
    public class Customer : ICustomer
        {
        public Customer()
            {
            //Orders = new HashSet<Order>();
            }

        public int CustomerId { get; set; }
        [Required]
        public string CustomerFirstName { get; set; }
        [Required]
        public string CustomerLastName { get; set; }
        [Required]
        public string CustomerUserName { get; set; }
        [Required]
        public string CustomerPassWord { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public string CustomerStreet { get; set; }
        [Required]
        public string CustomerCityt { get; set; }
        [Required]
        public string CustomerState { get; set; }
        [Required]
        public int CustomerStore { get; set; }

        public virtual LocationDirectory CustomerStoreNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        }
    }
