using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Inventory
    {
        protected List<Item> inventory = new List<Item>();
        public int MaxInventory = 7;


        /// <summary>
        /// Returns the values of all items the user has in their inventory list
        /// </summary>
        /// <returns>List of all items the user has in their inventory</returns>
        public string GetInventoryContents(List<Item> items)
        {
            Console.WriteLine($"\nInventory: {items.Count} / {MaxInventory}");
            foreach (var item in items)
            {
                item.Output();
            }
            ExceedInventory(items);
            return items.Count.ToString();
        }
        /// <summary>
        /// Returns the values of all potions the user has in their inventory list. Weapons aren't included in this list.
        /// </summary>
        /// <param name="items">The list of the items the inventory filters for the potions</param>
        /// <returns>Amount of items in the inventory</returns>
        public string GetPotionsInInventory(List<Item> items)
        {
            Console.WriteLine("Potions in User's inventory:");
            foreach (Potion potion in items.Where(x => x is Potion))
            {
                potion.Output();
            }
            return items.Count.ToString();
        }
        /// <summary>
        /// This is overriden in the weapon and potion class to display the parameters of these items in the inventory
        /// </summary>
        public virtual void Output()
        {
            Console.WriteLine(inventory.Count());
        }
        /// <summary>
        /// Allows the user to discard an item from their inventory when called. The user is prompted to enter the name of the item they want to discard and if it is in their inventory, it is removed.
        /// </summary>
        /// <param name="items">List of items in their inventory</param>
        public void Discard(List<Item> items)
        {
            try
            {
                Console.WriteLine("Enter the name of the item to discard.");
                if (items.Count == 0)
                {
                    Console.WriteLine("No inventory items to discard.");
                    return;
                }
                string itemName = Console.ReadLine().ToLower();
                var itemRemove = items.FirstOrDefault(i => i.Name.ToLower() == itemName.ToLower());
                if (itemRemove != null)
                {
                    items.Remove(itemRemove);
                    Console.WriteLine($"{itemRemove} removed from inventory.");
                }
                else if (string.IsNullOrWhiteSpace(itemName))
                {
                    throw new ArgumentNullException($"Error: Null or empty item choice. You must enter a valid item in your inventory as displayed above.");
                }

                else
                {
                    throw new ArgumentOutOfRangeException($"Error: Invalid inventory Item {itemRemove}. You must type an item in your inventory shown above.");
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        /// <summary>
        /// Monitors the stock of the player's inventory and ensures that the count of items doesnt exceed the limit forcing the user to discard items when necessary
        /// </summary>
        /// <param name="items">Player's inventory</param>
        public void ExceedInventory(List<Item> items)
        {
            try
            {
                if (items.Count > MaxInventory)
                {
                    Console.WriteLine("\nInventory exceeded limit.");
                    Discard(items);
                    GetInventoryContents(items);
                }
                else if (items.Count < MaxInventory)
                {
                    Console.WriteLine("\nInventory is within range.");
                }
                else
                {
                    Console.WriteLine("\nInventory Full");
                }
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
