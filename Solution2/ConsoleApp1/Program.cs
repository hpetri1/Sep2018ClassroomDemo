using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Returns a new DateTime that adds the value of the specified TimeSpan to the value of this instance.
            //A positive or negative time interval.
            //An object whose value is the sum of the date and time represented by this instance and the time interval represented by value.

            //public DateTime Add (TimeSpan value);
            System.DateTime today = System.DateTime.Now;
            System.TimeSpan duration = new System.TimeSpan(7, 0, 0, 0);
            System.DateTime answer = today.Add(duration);
            System.Console.WriteLine("{0:dddd}", answer);


            //Returns a new DateTime that adds the specified number of hours to the value of this instance.
            //A number of whole and fractional hours. The value parameter can be negative or positive.
            //An object whose value is the sum of the date and time represented by this instance and the number of hours represented by value.

            //public DateTime AddHours (double value);
            double hours = -5;
            DateTime currentime = new DateTime(2018, 12, 7, 12, 0, 0);
            DateTime answer2 = currentime.AddHours(hours);
            Console.WriteLine(answer2);
            Console.WriteLine("{0} + {1} hour(s) = {2}", currentime, hours,
                            currentime.AddHours(hours));


            //Returns a new DateTime that adds the specified number of days to the value of this instance.
            //A number of whole and fractional days. The value parameter can be negative or positive.
            //An object whose value is the sum of the date and time represented by this instance and the number of days represented by value.

            //public DateTime AddDays (double value);
            DateTime todaysDate = DateTime.Now;
            DateTime answer3 = todaysDate.AddDays(36);
            Console.WriteLine("Today: {0:yyyy-MM-dd, dddd, hh-mm-ss}", todaysDate);
            Console.WriteLine("36 days from today: {0:dddd}", answer3);


            Console.WriteLine(todaysDate);
            Console.ReadLine();
        }
    }
}
