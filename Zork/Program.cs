using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zork
{
    class Program
    {
        static void Main(string[] args)
        {

            const string defaultGameFilename = "Zork.json";
            string gameFilename = (args.Length > 0 ? args[(int)CommandLineArguments.GameFilename] : defaultGameFilename);
            Game game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(gameFilename));
            game.Run();

        }

        

        //private static bool IsDirection(Commands command) => Directions.Contains(command);

        

        //private static readonly List<Commands> Directions = new List<Commands>
        //{
        //    Commands.NORTH,
        //    Commands.SOUTH,
        //    Commands.EAST,
        //    Commands.WEST
        //};

        private enum CommandLineArguments
        {
            GameFilename = 0
        }
    }
}