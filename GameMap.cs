using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class GameMap
    {
        List<Room> rooms = new List<Room>();
        Random random = new Random();
        /// <summary>
        /// Names of the rooms in the dungeon.
        /// </summary>
        readonly string[] roomNames = { "Hallway", "Library", "Living Room", "Trap Room", "Stairway", "Headquarters", "Throne Room" };
        /// <summary>
        /// Descriptions of the rooms in the dungeon.
        /// </summary>
        readonly string[] roomDescription = { "Broken debris lay on the cold wet ground creating a crevice in the ceiling", "Spacious room dimmed by the limited amount of torches scattered to fill the void.", "Vandilised with Goblin memorabilia and tampered for self pleasure." };
        /// <summary>
        /// Outputs the map of the dungeon with the amount of rooms it contains.
        /// </summary>
        public void ViewMap()
        {
            const string underline = "\x1B[4m";
            const string reset = "\x1B[24m";
            Console.WriteLine(underline + $"Dungeon Map containing {rooms.Count} rooms" + reset);
            foreach (var roo in rooms)
            {
                roo.RoomMap();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual void RoomMap()
        { }
        /// <summary>
        /// 
        /// </summary>
        public virtual void RoomDescription()
        { }

        /// <summary>
        /// Outputs the current room the player is in.
        /// </summary>
        /// <param name="index">Index for the room with 0 being the entrance and 6 being the exit.</param>
        public void CurrentRoom(int index)
        {
            for (int i = index; i < index + 1; i++)
            {
                rooms[i].RoomDescription();
            }
        }

        /// <summary>
        /// Creates a map of the dungeon with a specified number of rooms (Ecluding the entrance and exit).
        /// </summary>
        /// <param name="amountOfRooms">Amount of rooms excluding the entrance and exit the dungeon contains</param>
        public void CreateMap(int amountOfRooms)
        {

            rooms.Add(new Room("Dungeon Entrance", "Entrance of the dungeon"));
            for (int i = 0; i < amountOfRooms; i++)
            {
                rooms.Add(new Room(roomNames[random.Next(roomNames.Length)], roomDescription[random.Next(roomDescription.Length)]));
            }
            rooms.Add(new Room("Dungeon Exit", "Contains a strong aura ahead guarding riches and the player's escape."));
            ViewMap();
        }
    }
}
