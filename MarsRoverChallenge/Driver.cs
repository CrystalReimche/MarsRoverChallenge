using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsRoverChallenge
{
    class Driver
    {
        /// <summary>
        /// Driver's name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Checking if driver still wants to drive the Rover
        /// </summary>
        public bool StillDriving { get; set; }

        int x;
        int y;
        string userStartingDirection;
        bool valid = false;
        
        /// <summary>
        /// Takes in starting X,Y and Direction position, then ask for user input for movement
        /// </summary>
        /// <param name="driverName"></param>
        /// <returns></returns>
        public bool Drive(string driverName)
        {
            Name = driverName;
            var driver = new Driver();
            var rover = new Rover();

            // Keep asking for X coordinate until given a valid value
            do
            {
                Console.WriteLine("Please enter a starting X point, between 0 and 5.");
                string userStartingX = Console.ReadLine().ToLower();

                // Make sure user entered a valid number
                if (int.TryParse(userStartingX, out x))
                {
                    if (x >= 0 && x <= 5)
                    {
                        rover.CurrentXYCoords = new Point(x, rover.CurrentXYCoords.Y);
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Digits only, please choose from the following: 0, 1, 2, 3, 4, 5");
                        valid = false;
                    }
                }
            } while (valid == false);

            // Keep asking for Y coordinate until given a valid value
            do
            {
                Console.WriteLine("Please enter a starting Y point, between 0 and 5.");
                string userStartingY = Console.ReadLine().ToLower();

                // Make sure user entered a valid number
                if (int.TryParse(userStartingY, out y))
                {
                    if (y >= 0 && y <= 5)
                    {
                        rover.CurrentXYCoords = new Point(rover.CurrentXYCoords.X, y);
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Digits only, please choose from the following: 0, 1, 2, 3, 4, 5");
                        valid = false;
                    }
                }
            } while (valid == false);

            // Keep asking for starting direction until given valid value
            do
            {
                Console.WriteLine("Please enter a starting direction for the Rover to face. Type in 'N', 'S', 'E', or 'W'");
                userStartingDirection = Console.ReadLine().ToLower();

                // Make sure user entered a valid direction
                if (userStartingDirection == "n" || userStartingDirection == "s" || userStartingDirection == "e" || userStartingDirection == "w")
                {
                    if (userStartingDirection == "n") { rover.CurrentFacingDirection = Direction.N; valid = true; }
                    else if (userStartingDirection == "s") { rover.CurrentFacingDirection = Direction.S; valid = true; }
                    else if (userStartingDirection == "e") { rover.CurrentFacingDirection = Direction.E; valid = true; }
                    else if (userStartingDirection == "w") { rover.CurrentFacingDirection = Direction.W; valid = true; }
                }
                else
                {
                    Console.WriteLine("Please enter either N, S, E, or W");
                    valid = false;
                }
            } while (valid == false);


            Console.Write("Landing rover at ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("(" + rover.CurrentXYCoords.X + ", " + rover.CurrentXYCoords.Y + ")");
            Console.ResetColor();
            Console.Write(" facing ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(rover.CurrentFacingDirection);
            Console.ResetColor();
            Console.Write(" ... ");
            Thread.Sleep(2000);
            Console.Write("landed.\n\n");

            string input = "";

            // While driver doesn't want to quit, take driver instructions to move Rover
            while (!input.ToLower().Equals("q"))
            {
                Console.WriteLine("Move Forward: press M, Turn Left: press L, Turn Right: press R OR type Q to quit:");
                input = Console.ReadLine().ToLower();

                if (!input.ToLower().Equals("q"))
                {
                    if (input == "m")
                        rover.MoveForward();
                    else if (input == "l")
                        rover.Turn(input);
                    else if (input == "r")
                        rover.Turn(input);
                    else
                        Console.WriteLine("I'm so lost... maybe take another look at the map.");

                    rover.DisplayNewPosition();

                    if (rover.CheckIfOutOfBounds() == true)
                        break;
                }
            }

            // When Rover goes off grid, ask driver if they want to ride again, repeat game until they say no
            while (driver.StillDriving != true)
            {
                Console.WriteLine("Would you like to ride again?");
                string answer = Console.ReadLine().ToLower();
                if (answer == "yes" || answer == "yeah" || answer == "y" || answer == "ya" || answer == "yea")
                {
                    driver.StillDriving = true;
                    driver.Drive(driver.Name);
                }
                else
                {
                    driver.StillDriving = false;
                    break;
                }
            }
            return true;
        }
    }
}
