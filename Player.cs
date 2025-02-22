using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>(1);

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }
        public void PickUpItem(string item)
        {

            Console.WriteLine($"Item Acquired: {item}");
            //Player.inventory.Add(item);
            inventory.Add(item);
            //Console.WriteLine(inventory);
            
        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory);

        }
    }
}