using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
    {
    interface ICustomer
        {
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
        }
    }
