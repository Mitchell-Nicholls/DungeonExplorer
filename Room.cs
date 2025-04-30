using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room : GameMap
    {
        private string roomDescription;
        private string roomName;
        /// <summary>
        /// This method maintains the details of the user's room
        /// </summary>
        /// <param name="roomName">Name of the user's current room</param>
        /// <param name="roomDescription">Description of the room the user's currently in</param>

        public Room(string roomName, string roomDescription)
        {
            this.roomName = roomName;
            this.roomDescription = roomDescription;
        }

        /// <summary>
        /// This method displays the room name and description and identifies when the room is a trap room allowing the user to choose whether to run or walk carefully
        /// </summary>
        public override void RoomDescription()
        {
            Console.WriteLine($"\n{roomName}: {roomDescription}");
            if (roomName.Contains("Trap Room"))
            {
                Console.WriteLine("This is a trap room. You have a choice to make.");
                Console.WriteLine("1. Run through the room\n2. Walk Carefully");
                string trapChoice = Console.ReadLine();
                if (trapChoice == "1")
                {
                    Console.WriteLine("You ran through the room and fell into a pit of spikes");
                }
                else if (trapChoice == "2")
                {
                    Console.WriteLine("You walked carefully and avoided the trap");
                }
                else
                {
                    Console.WriteLine("Invalid choice, you fell into a pit of spikes");
                }
            }
        }
    }
}