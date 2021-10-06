using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zork
{
    public class Player
    {
        public World World { get; }

        [JsonIgnore]
        public Room CurrentRoom
        {
            get
            {
                return World.Rooms[Location.Row, Location.Column];
            }
        }

        public Player (World world, string startingLocation)
        {
            World = world;

            for (int row = 0; row < World.Rooms.GetLength(0); row++)
            {
                for (int column = 0; column < World.Rooms.GetLength(1); column++)
                {
                    if (World.Rooms[row, column].Name.Equals(startingLocation, StringComparison.OrdinalIgnoreCase))
                    {
                        Location = (row, column);
                        return;
                    }
                }
            }
        }

        //public bool Move(Commands command)
        //{
        //    Assert.IsTrue(Directions.Contains(command), "Invalid Direction.");
        //    bool isValidMove = true;

        //    switch (command)
        //    {
        //        case Commands.NORTH when Location.Row < Rooms.GetLength(0) - 1:
        //            Location.Row++;
        //            break;

        //        case Commands.SOUTH when Location.Row > 0:
        //            Location.Row--;
        //            break;

        //        case Commands.EAST when Location.Column < Rooms.GetLength(1) - 1:
        //            Location.Column++;
        //            break;

        //        case Commands.WEST when Location.Column > 0:
        //            Location.Column--;
        //            break;

        //        default:
        //            isValidMove = false;
        //            break;
        //    }

        //    return isValidMove;
        //}

        private (int Row, int Column) Location;
    }
}
