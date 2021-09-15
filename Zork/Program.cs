using System;

namespace Zork
{
    class Program
    {
        private static string CurrentRoom
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            Commands command =  Commands.UNKNOWN;   
            while (command != Commands.QUIT) 
            {
                Console.WriteLine(CurrentRoom);
                command = ToCommand(Console.ReadLine().Trim());

                switch (command)
                {
                    case Commands.QUIT:
                        Console.WriteLine("Thank you for playing");
                        break;

                    case Commands.LOOK:
                        Console.WriteLine("This is an open field west of a white house, with a boarded front door. \nA rubber mat saying 'Welcome to Zork!' lies by the door.");
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        Console.WriteLine(Move(command) ? $"You Moved {command}." : "The way is shut!");

                        break;

                    default:
                        Console.WriteLine("Unrecognized command");
                        break;
                }

                   // Console.WriteLine(CurrentRoom);
            }

            Console.WriteLine("Finished.");
        }

        private static bool Move(Commands command)
        {
            bool didMove = false;

            switch (command)
            {
                case Commands.NORTH when Location.Row < Rooms.Length - 1:
                    Location.Row++;
                    didMove = true;
                    break;

                case Commands.SOUTH when Location.Row > 0:
                    Location.Row--;
                    didMove = true;
                    break;

                case Commands.EAST when Location.Column < Rooms.Length - 1:
                    Location.Column++;
                    didMove = true;
                    break;

                case Commands.WEST when Location.Column > 0:
                    Location.Column--;
                    didMove = true;
                    break;
            }

            return didMove;
        }

        private static Commands ToCommand(string commandString) => Enum.TryParse<Commands>(commandString, true, out Commands command) ? command : Commands.UNKNOWN;

        private static readonly string[,] Rooms = {
            {  "Rocky Trail", "South of house", "Canyon view"},
            { "Forest", "West of House", "Behind House" },
            { "Dense Woods", "North of House", "Clearing" }
           };

        //private static int LocationColumn = 1;
        //private static int LocationRow = 1;

        private static (int Row, int Column) Location = (1, 1);

    }
}