using Models;
using Proj0DBContext;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Project0Blayer
{
    public class AccountAccess : AddToDB
    {
        private static readonly Project0Context _context = new Project0Context();
        /// <summary>
        /// Welcome Message to store, offers to log in or register
        /// </summary>
        /// <returns></returns>
        /// 
        
        public int WelcomeMessage()
        {
            Console.WriteLine("**********************************************************");
            Console.WriteLine("Welcome to Improbable Tech!\nWhere NOTHING is impossible\nOnly Improbable!" +
                             "\n**********************************************************" +
                             "\nWould you like to \n1.Log In\n2.Register a new user" +
                             "\nPlease input the number:");
            //string choice = Console.ReadLine();
            int input = Convert.ToInt32(Console.ReadLine()); ;

            if (input != 1 && input != 2)
            {
                Console.WriteLine("That is not a valid entry please type 1 or 2");
                return 0;
            }
            return input;
        }
        /// <summary>
        /// Takes in username and pw and extracts location ID, and has out var as username
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int HasAccessExistingAccount(int input)
        {
            Console.WriteLine("Please enter your Username:");
            string inputUN = Console.ReadLine().Trim();
            var accounts = _context.Customers.Where(x => x.CustomerUserName == inputUN).ToList();
            foreach (var person in accounts)
            {
                if (inputUN.Trim().ToLower() != person.CustomerUserName.Trim().ToLower())
                {
                    Console.WriteLine("That is not a valid username, please register.");
                    userName = "";
                    return 2;
                }
                Console.WriteLine("Please enter your Password:");
                string userPassword = Console.ReadLine().Trim();
                if (person.CustomerPassWord == userPassword)
                {
                    userName = person.CustomerUserName;
                    return person.CustomerStore;
                }
            }
            System.Console.WriteLine("That is not a valid account");
            userName = " ";
            return 0;
        }

        /// <summary>
        /// Getting user info and validation
        /// </summary>
        /// <returns></returns>
        public string getUserName()
        {
            Console.WriteLine("Please input a UserName:");
            string userName = Console.ReadLine().Trim();
            
            return userName;
        }
        public string getUserPassword()
        {
            Console.WriteLine("Please input a password:");
            string userPassword = Console.ReadLine().Trim();
            if (userPassword.Length > 20 || userPassword.Length < 1)
            {
                Console.WriteLine("That is not a valid entry, please try again");
                return null;
            }
            return userPassword;
        }
        public string getUserFirstName()
        {
            Console.WriteLine("Please input your first name:");
            string userFirstName = Console.ReadLine().Trim();

            if (userFirstName.Length > 20 || userFirstName.Length < 1)
            {
                Console.WriteLine("That is not a valid entry, please try again");
                return null;
            }
            return userFirstName;
        }
        public string getUserLasttName()
        {
            Console.WriteLine("Please input your last name:");
            string userLastName = Console.ReadLine().Trim();
            if (userLastName.Length > 20 || userLastName.Length < 1)
            {
                Console.WriteLine("That is not a valid entry, please try again");
                return null;
            }
            return userLastName;
        }
        public string getUserEmail()
        {
            Console.WriteLine("Please input your email:");
            string userEmai = Console.ReadLine().Trim();
            if (userEmai.Length > 40 || userEmai.Length < 1)
            {
                Console.WriteLine("That is not a valid entry, please try again");
                return null;
            }
            return userEmai;
        }
        public string getUserStreetAdd()
        {
            Console.WriteLine("Please input your Street Address:");
            string street = Console.ReadLine().Trim();
            if (street.Length > 60 || street.Length < 1)
            {
                Console.WriteLine("That is not a valid entry, please try again");
                return null;
            }
            return street;
        }
        public string getUserCityAdd()
        {
            Console.WriteLine("Please input your City:");
            string city = Console.ReadLine().Trim();
            if (city.Length > 60 || city.Length < 1)
            {
                Console.WriteLine("That is not a valid entry, please try again");
                return null;
            }
            return city;
        }
        public string getUserStateAdd()
        {
            Console.WriteLine("Please input your State, use 2 letters:");
            string state = Console.ReadLine().Trim();
            if (state.Length > 2 || state.Length < 1)
            {
                Console.WriteLine("That is not a valid entry, please try again");
                return null;
            }
            return state;
        }
        /// <summary>
        /// This will print to user the default location details and offer to change, returns store location
        /// </summary>
        /// <returns></returns>
        public int getUserStore()
        {
            int location = 100;//set default store location, now offering the options
            int choice = 0;
            List<LocationDirectory> myStore = _context.LocationDirectories.ToList();//this pulls from db

            foreach (var mydefault in myStore.Where(x => x.StoreId == location))
            { //prints default store info
                Console.WriteLine($"Your store is set to:\nID: 1{mydefault.StoreId} {mydefault.StoreName}\n" +
                    $"Located at {mydefault.StoreStreetAd} {mydefault.StoreCitytAd} {mydefault.StoreStateAd}\n" +
                    $"If you want to choose another location please enter 1, otherwise hit any key");
                bool inputIsTrue = Int32.TryParse(Console.ReadLine(), out choice);//offers to change store
            }
            if (choice == 1)// if user chose to change then it pulls all from db and prints out options
            {
                Console.WriteLine("Please input the store ID of the store you would preffer");
                foreach (var store in myStore)
                {
                    Console.WriteLine($"Store ID: {store.StoreId} {store.StoreName} " +
                        $"Located {store.StoreStreetAd} {store.StoreCitytAd} {store.StoreStateAd}\n");
                }
                bool input1 = Int32.TryParse(Console.ReadLine(), out location);
            }
            return location;
        }
        public int AddCustomer(string fname, string lname, string username,
           string pw, string email, string street, string city, string state, int storeID)
        {
            var newUser = new Customer()
            {
                CustomerFirstName = fname,
                CustomerLastName = lname,
                CustomerUserName = username,
                CustomerPassWord = pw,
                CustomerEmail = email,
                CustomerStreet = street,
                CustomerCityt = city,
                CustomerState = state,
                CustomerStore = storeID

            };
            Console.WriteLine("***************************************************");
            Console.WriteLine($"Thank you {fname} {lname}!\nYour account has been registered.");
            _context.Customers.Add(newUser);
            _context.SaveChanges();
            var userID = _context.Customers.Select(x => x.CustomerId).Last();
            return userID;

        }
    }

}