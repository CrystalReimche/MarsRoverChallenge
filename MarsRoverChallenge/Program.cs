using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MarsRoverChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome to Off Road Rover!\nPlease enter your name (for legal reasons): ");
            string driverName = Console.ReadLine();

            Console.Write($"Hello {driverName}! Are you ready to rock this Rover on Mars?? \n(disclaimer... you break it, you buy it): ");
            string answer = Console.ReadLine().ToLower();

            // Check if they are ready to drive
            if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "ya" || answer == "yea")
            {
                // If yes, instantiate a new driver and rover
                Driver driver = new Driver() { Name = driverName }; ;
                Rover rover = new Rover();
                // Call the drive()
                driver.Drive(driverName);

                Console.WriteLine("You have exited the Off Road Rover, please bring oxygen if you plan on exploring Mars on foot!");
            }
            Console.ReadKey();
        }
    }
}


