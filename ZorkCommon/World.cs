using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Runtime.Serialization;

namespace Zork
{
    public class World
    {
       public HashSet<Room> Rooms { get; set; }

        [JsonIgnore]
       public Dictionary<string, Room> RoomsByName => mRoomsByName;

       public Player SpawnPlayer() => new Player(this, StartingLocation);

        //public List<Room> Rooms { get; }

        //public World(IEnumerable<Room> rooms)
        //{
        //    Rooms = new List<Room>(rooms);
        //}

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            mRoomsByName = Rooms.ToDictionary(room => room.Name, room => room);

            foreach (Room room in Rooms)
            {
                room.UpdateNeighbors(this);
            }

        }

        [JsonProperty]
        private string StartingLocation { get; set; }

        private Dictionary<string, Room> mRoomsByName;
    }
}
