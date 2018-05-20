using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MarsRoverChallenge
{
    /// <summary>
    /// Enum for the directions: N, S, E, W
    /// </summary>
    enum Direction { N, S, E, W };

    class Rover
    {
        /// <summary>
        /// The current X,Y co-ordinates of Rover
        /// </summary>
        public Point CurrentXYCoords { get; set; }
        /// <summary>
        /// The current direction that the Rover is facing: N, S, E, W
        /// </summary>
        public Direction CurrentFacingDirection { get; set; }

        /// <summary>
        /// Default Constructor with no parameters
        /// </summary>
        public Rover() { }

        /// <summary>
        /// Constructor that takes starting X,Y position and direction
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        public Rover(int x, int y, Direction direction)
        {
            CurrentXYCoords = new Point(x, y);
            CurrentFacingDirection = direction;
        }

        /// <summary>
        /// Changes X,Y values of Rover based on user input for movement
        /// </summary>
        /// <returns></returns>
        public bool MoveForward()
        {
            if (CurrentFacingDirection == Direction.N) IncrementY();
            else if (CurrentFacingDirection == Direction.S) DecrementY();
            else if (CurrentFacingDirection == Direction.E) IncrementX();
            else if (CurrentFacingDirection == Direction.W) DecrementX();

            return true;
        }

        /// <summary>
        /// Takes current X,Y and checks if they are outside the grid boundary
        /// </summary>
        /// <returns></returns>
        public bool CheckIfOutOfBounds()
        {
            if (CurrentXYCoords.X > 5 || CurrentXYCoords.X < 0)
            {
                Console.WriteLine("Rover went off the grid, lost communication.");
                return true;
            }
            else if (CurrentXYCoords.Y > 5 || CurrentXYCoords.Y < 0)
            {
                Console.WriteLine("Rover went off the grid, lost communication.");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Changes direction of Rover based on user input and current facing direction
        /// </summary>
        /// <param name="input"></param>
        public void Turn(string input)
        {
            if (input == "l")
            {
                if (CurrentFacingDirection == Direction.N) CurrentFacingDirection = Direction.W;
                else if (CurrentFacingDirection == Direction.W) CurrentFacingDirection = Direction.S;
                else if (CurrentFacingDirection == Direction.S) CurrentFacingDirection = Direction.E;
                else if (CurrentFacingDirection == Direction.E) CurrentFacingDirection = Direction.N;
                else
                    Console.WriteLine("We're so lost... I hope you know how to read a map!");
            }
            else if (input == "r")
            {
                if (CurrentFacingDirection == Direction.N) CurrentFacingDirection = Direction.E;
                else if (CurrentFacingDirection == Direction.E) CurrentFacingDirection = Direction.S;
                else if (CurrentFacingDirection == Direction.S) CurrentFacingDirection = Direction.W;
                else if (CurrentFacingDirection == Direction.W) CurrentFacingDirection = Direction.N;
                else
                    Console.WriteLine("Please pull over and ask for directions!  I'm getting rover sickness...");
            }
            else
                Console.WriteLine("Maybe we have a flat tire, we don't seem to be going anywhere.");
        }

        /// <summary>
        /// Takes current X position and increases it by 1.
        /// </summary>
        private void IncrementX()
        {
            int newX = CurrentXYCoords.X + 1;
            CurrentXYCoords = new Point(newX, CurrentXYCoords.Y);
        }

        /// <summary>
        /// Takes current X position and decreases it by 1.
        /// </summary>
        private void DecrementX()
        {
            int newX = CurrentXYCoords.X - 1;
            CurrentXYCoords = new Point(newX, CurrentXYCoords.Y);
        }

        /// <summary>
        /// Takes current Y position and increases it by 1.
        /// </summary>
        private void IncrementY()
        {
            int newY = CurrentXYCoords.Y + 1;
            CurrentXYCoords = new Point(CurrentXYCoords.X, newY);
        }

        /// <summary>
        /// Takes current Y position and decreases it by 1.
        /// </summary>
        private void DecrementY()
        {
            int newY = CurrentXYCoords.Y - 1;
            CurrentXYCoords = new Point(CurrentXYCoords.X, newY);
        }

        /// <summary>
        /// Displays Rover current X,Y position and facing direction.
        /// </summary>
        public void DisplayNewPosition()
        {
            Console.WriteLine("Recalculating position ... please wait");
            Thread.Sleep(500);
            Console.Write("Your current position is ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("(" + CurrentXYCoords.X + ", " + CurrentXYCoords.Y + ")");
            Console.ResetColor();
            Console.Write(" facing ");
            Console.ForegroundColor = ConsoleColor.Green;
            if (CurrentFacingDirection == Direction.N) Console.Write("North.\n");
            else if (CurrentFacingDirection == Direction.S) Console.Write("South.\n");
            else if (CurrentFacingDirection == Direction.E) Console.Write("East.\n");
            else if (CurrentFacingDirection == Direction.W) Console.Write("West.\n");
            Console.ResetColor();

            Console.WriteLine();
        }
    }
}
