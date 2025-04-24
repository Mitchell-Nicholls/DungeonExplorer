using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Item : Inventory, ICollectable
    {
        public string Name { get; set; }
        /// <summary>
        /// Item class is the base class for all items in the game. Currently contains a name for items and is instantiated for weapons and potions.
        /// </summary>
        /// <param name="name">Name of the item.</param>
        public Item(string name)
        {
            Name = name;
        }
        /// <summary>
        /// Adds the item type to the player's inventory list. This method is overridden in derived classes potions and weapons.
        /// </summary>
        /// <param name="itemName">Name of the item to add to the inventory</param>
        /// <param name="itemStat">Statistic of the item being added to the inventory</param>
        public virtual void AddItem(string itemName, int itemStat)
        { }
    }
    public class Weapon : Item
    {
        public int AverageDamage { get; set; }
        /// <summary>
        /// Weapon class is the derived class of item. It contains the name of the weapon and the max damage the weapon can apply.
        /// </summary>
        /// <param name="name">Weapon Name</param>
        /// <param name="averageDamage">Weapon Max Damage</param>
        public Weapon(string name, int averageDamage) : base(name)
        {
            {
                AverageDamage = averageDamage;
            }

        }
        /// <summary>
        /// Adds the weapon to the player's inventory using name, damage, and the list it is being added to.
        /// </summary>
        /// <param name="itemName"></param>
        /// <param name="itemStat"></param>
        /// <param name="items"></param>
        public void AddItem(string itemName, int itemStat, List<Item> items)
        {
            items.Add(new Weapon(itemName, itemStat));
            Console.WriteLine($"As a reward, the enemy dropped {itemName} dealing {itemStat} damage.");
            Console.WriteLine($"{itemName} weapon is acquired in the player's inventory.");
        }
        /// <summary>
        /// Outputs the weapon's name and maximum damage to the console. This is used for all weapons in the player's inventory.
        /// </summary>
        public override void Output()
        {
            Console.WriteLine($"Weapon: {Name} \tAverage: {AverageDamage} damage");
        }
    }
    public class Potion : Item
    {
        public int HealAmount { get; set; }

        /// <summary>
        /// Potion class is the derived class of item. It contains the name of the potion and the heal amount for the player.
        /// </summary>
        /// <param name="name">Name of the potion</param>
        /// <param name="healamount">The amount the potion heals the player</param>
        public Potion(string name, int healamount) : base(name)
        {
            HealAmount = healamount;
        }
        /// <summary>
        /// Returns the properties of all potions in the player's inventory including name and heal amount.
        /// </summary>
        public override void Output()
        {
            Console.WriteLine($"Potion: {Name} \tHeals: {HealAmount} health ");
        }
        /// <summary>
        /// Adds the potion to the player's inventory using name, heal amount, and the list it is being added to. This class is inherited from the icollectable interface through the item class as a virtual method.
        /// </summary>
        /// <param name="itemName">Name of the potion</param>
        /// <param name="itemStat">The stat of the potion being added</param>
        /// <param name="items">The list the potion is being added to</param>
        public void AddItem(string itemName, int itemStat, List<Item> items)
        {
            items.Add(new Potion(itemName, itemStat));
            Console.WriteLine($"{itemName} is acquired in the player's inventory.");
        }
    }
}
