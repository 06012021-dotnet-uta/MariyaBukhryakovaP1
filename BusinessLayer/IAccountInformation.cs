using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
    {
    interface IAccountInformation
        {
        public int CustomerID { get; set; }
        public void AccountHistoryMessage();
        public void AccountOptions();
        public int SearchOtherUser();
        public int DisplayMyOrders(string userName);
        public int DisplayLocationOrders();
        }
    }
