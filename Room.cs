namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private string roomName;

        /// <summary>
        /// This method maintains the details of the user's room
        /// </summary>
        /// <param name="roomName">Name of the user's current room</param>
        /// <param name="description">Description of the room the user's currently in</param>
        public Room(string roomName, string description)
        {
            this.roomName = roomName;
            this.description = description;
        }
        /// <summary>
        /// Returns the string of the room description
        /// </summary>
        /// <returns>Current Room description the user is in.</returns>
        public string GetDescription()
        {
            return description;
        }
        /// <summary>
        /// Returns the string of the room name
        /// </summary>
        /// <returns>Name of the room the user is currently in</returns>
        public string GetRoomName()
        {
            return roomName;
        }
    }
}