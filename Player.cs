﻿using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; set; }
        //private List<string> inventory = new List<string>();
        private List<string> inventory = new List<string>();

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }
        public void PickUpItem(string item)
        {

            //Console.WriteLine($"Item Acquired: {item}");
            inventory.Add(item);
            
        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory);

        }
        public void ClearItems()
        {
            Console.WriteLine("Inventory reset ");
            inventory.Clear();
        }
        /*public void RemoveItem(string item)
        {
            inventory.TryGetValue(item, out int quantity);
            quantity--;
        }*/
    }
}