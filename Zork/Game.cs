using System;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Zork
{
    public class Game
    {
        public World World { get; set; }

        public string StartingLocation { get; set; }

        [JsonIgnore]
        public Player Player { get; private set; }

        [JsonIgnore]
        private bool IsRunning { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Player = new Player(World, StartingLocation); 
        }

        public void Run()
        {
            Console.WriteLine("Welcome to Zork!");

            IsRunning = true;
            Room previousRoom = null;
            while (IsRunning)
            {
                Console.WriteLine(Player.CurrentRoom);

                if (previousRoom != Player.CurrentRoom)
                {
                    Console.WriteLine(Player.CurrentRoom.Description);
                    previousRoom = Player.CurrentRoom;
                }

                Console.Write("> ");
                Commands command = ToCommand(Console.ReadLine().Trim());
                 
                switch (command)
                {
                    case Commands.QUIT:
                        Console.WriteLine("Thank you for playing");
                        break;

                    case Commands.LOOK:
                        Console.WriteLine(Player.CurrentRoom.Description);
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:

                        //if (Move(command) == false)
                        //{
                        //    Console.WriteLine("The way is shut!");
                        //}
                        //break;

                    default:
                        Console.WriteLine("Unrecognized command");
                        break;
                }
            }

            Console.WriteLine("Finished.");
        }
        
        private static Commands ToCommand(string commandString) => Enum.TryParse<Commands>(commandString, true, out Commands command) ? command : Commands.UNKNOWN;
    }
}
