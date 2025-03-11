using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; set; }
        private List<string> inventory = new List<string>();

        /// <summary>
        /// Manages the value of the name and health
        /// </summary>
        /// <param name="name">The current name of the user in the game</param>
        /// <param name="health">The current health the user has in the game</param>
        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }
        /// <summary>
        /// Adds the item the user picked up and placed it in their inventory list
        /// </summary>
        /// <param name="item">Name of the item the user added to their inventory</param>
        public void PickUpItem(string item)
        {
            inventory.Add(item);
            
        }
        /// <summary>
        /// Returns the values of all items the user has in their inventory list
        /// </summary>
        /// <returns>List of all items the user has in their inventory</returns>
        public string GetInventoryContents()
        {
            return string.Join(", ", inventory);

        }
        /// <summary>
        /// Resets the user's inventory to null when called
        /// </summary>
        public void ClearInventoryItems()
        {
            Console.WriteLine("Inventory reset ");
            inventory.Clear();
        }
    }
}