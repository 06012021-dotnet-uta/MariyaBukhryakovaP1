using System;
using System.Collections.Generic;

namespace Week4Challenge
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Requests N to be entered and converts
            Console.WriteLine("Enter N:");
            int n = Convert.ToInt32(Console.ReadLine().Trim());
        
        //for loop, to repeat n times
            for (int i = 0; i <= n; i++)
                {
                //initializes string and using one of String's overladed constructors to add
                //the # symbol at i index
                string row = new string('#', i);
                //printing out the row
                Console.WriteLine(row.PadLeft(n+1));
                //and for loop takes previous string n and adds to string to continue printing 
                //untill it's repeated 1-n times.
                }
           
            }
    }
}
