
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Proj0DBContext;

namespace Project0Blayer
{
    public class AccountInformation
    {
        public AccountInformation(string userName)
        {
            this.MyUserName = userName;
        }
        public string MyUserName { get; set; }
        public Project0Context _context = new Project0Context();
        /// <summary>
        /// Prompting the user to register and a returen message for each field... do I want that?!
        /// </summary>
        public int AccountHistoryMessage()
        {
            var Accounts = _context.Customers.Where(x => x.CustomerUserName == MyUserName).ToList();
            int userInput = 0;


            foreach (var user in Accounts)
            {
                Console.WriteLine("**********************************************************");
                Console.WriteLine($"Welcome {user.CustomerFirstName} {user.CustomerLastName}");
                Console.WriteLine("Would you like to: \n1.Search for all active users by name and display their order history" +
                    "\n2.Display your order history\n3.Review a location's order history\n4.Go shopping!" +
                                 "\n**********************************************************" +
                                 "\nPlease input your choice:");
            }
            userInput = Convert.ToInt32(Console.ReadLine());
            return userInput;

        }
        public int AccountOptions()
        {
            var Accounts = _context.Customers.Where(x => x.CustomerUserName == MyUserName).ToList();
            foreach (var user in Accounts)
            {
                Console.WriteLine("**********************************************************");
                Console.WriteLine($"Hello {user.CustomerFirstName} {user.CustomerLastName}!");
                Console.WriteLine("Would you like to: \n1.Access your Account\n2.Go shopping!" +

                                 "\n**********************************************************" +
                                 "\nPlease input your choice:");
            }
            int userInput = Convert.ToInt32(Console.ReadLine());
            return userInput;

        }
        /// <summary>
        /// user selects from Account options and it takes them to 
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public int SearchOtherUser()
        {
            int userInput = 0;
            int accID = 0;
            var CustomandOrders = _context.Orders.Include(x => x.OrderAccountNavigation).ToList();
            var StoreandProd = _context.LocationDirectories.Include(x => x.Stores).ThenInclude(y => y.StoreProduct).ToList();


            foreach (var account in Customer)
            {
                Console.WriteLine("Please enter the First name of the user you are searching for:");
                string fname = Console.ReadLine();
                Console.WriteLine("Please enter the Last name of the user you are searching for:");
                string lname = Console.ReadLine();
                if (account.CustomerFirstName.ToLower().Trim() == fname.ToLower().Trim() && account.CustomerLastName.ToLower().Trim() == lname.ToLower().Trim())
                {
                    accID = account.CustomerId;
                    var Orders = _context.Orders.Where(x => x.OrderAccount == accID).ToList().OrderBy(x => x.OrderDate);
                    Console.WriteLine($"All orders for {account.CustomerFirstName} {account.CustomerLastName}, {account.CustomerId}");
                    foreach (var p in Orders)
                    {
                        Console.WriteLine($"OrderID: {p.OrderId} Order Date: {p.OrderDate}, Order Store ID: {p.OrderStore} Product ID: {p.OrderProductId} Number Of Items: {p.NumberofProducts}");
                    }
                }
            }
            Console.WriteLine("Would you like to seach for another user? Enter y, or would you like to start Shopping? Enter 4");
            userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput == 4) return userInput;
            return 0;
        }
        /// <summary>
        /// THis will return all order data for user
        /// </summary>
        /// <param name="userName"></param>
        public int DisplayMyOrders(string userName)
        {
            int userInput = 0;
            var myAccount = _context.Customers.Where(x => x.CustomerUserName == userName);
            var myOrders = _context.Orders.Include(x => x.OrderAccount).ToList();
            foreach (var c in myAccount)
            {
                foreach (var o in myOrders)
                {
                    decimal total = 0.00M;
                    if (o.OrderId == o.OrderId && o.OrderProductId == o.OrderProduct.ProductId && o.OrderAccount == c.CustomerId)
                    {
                        total = (decimal)(o.OrderProductQantity * o.OrderProduct.ProductPrice);
                        Console.WriteLine($"OrderID: {o.OrderId} Order Date: {o.OrderDate}, Item Name: {o.OrderProduct.ProductName} Product ID: {o.OrderProductId} Number Of Items: {o.NumberofProducts}");
                        Console.WriteLine($"Price Of each Item: {o.OrderProduct}  {o.OrderDate}, Item Name: {o.OrderProduct.ProductName} Product ID: {o.OrderProductId} Number Of Items: {o.NumberofProducts}");

                        Console.Write("Total Price {0:C}", total);
                        Console.WriteLine("Would you like to start shopping? Press 4");
                    }

                    userInput = Convert.ToInt32(Console.ReadLine());
                    if (userInput != 4)
                    {
                        Console.WriteLine("That was not a valid entry ");
                    }
                }
            }
            return userInput;
        }
        public int DisplayLocationOrders()
        {
            int userInput = 0;
            do
            {
                var stores = _context.LocationDirectories.ToList();
                foreach (var store in stores)
                {
                    Console.WriteLine($"Store ID: {store.StoreId} {store.StoreName} " +
                               $"Located {store.StoreStreetAd} {store.StoreCitytAd} {store.StoreStateAd}\n");
                }
                Console.WriteLine("**********************************************************");
                Console.WriteLine($"Please input the store ID you would like to see all inventory for:");
                Console.WriteLine("**********************************************************");
                int location = Convert.ToInt32(Console.ReadLine());
                var myOrders = _context.Orders.Include(x => x.OrderProduct).Where(y => y.OrderStoreId == location).ToList();
                foreach (var o in myOrders)
                {
                    decimal total = 0.00M;
                    if (o.OrderId == o.OrderId && o.OrderProductId == o.OrderProduct.ProductId)
                    {
                        total = (decimal)(o.NumberofProducts * o.OrderProduct.ProductPrice);
                    }
                    Console.WriteLine($"\nOrderID: {o.OrderId} Order Date: {o.OrderDate}, \nItem Name: {o.OrderProduct.ProductName} Product ID: {o.OrderProductId} \nNumber Of Items: {o.NumberofProducts}");
                    //Console.WriteLine($"Price Of each Item: {o.OrderProduct}  {o.OrderDate}, Item Name: {o.OrderProduct.ProductName} Product ID: {o.OrderProductId} Number Of Items: {o.NumberofProducts}");
                    Console.Write("Total Price {0:C}", total);
                }
                Console.WriteLine("Would you like to seach for another location? Enter 3, Or would you like to start shopping? Enter 4");
                userInput = Convert.ToInt32(Console.ReadLine());

            } while (userInput == 3);
            return userInput;

        }

    }//EOC
}//EON 