using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DungeonExplorer
{
    class Player : Creature, IDamageable
    {
        Random random;
        /// <summary>
        /// Manages the player's values in the game including name, health, weapon, and damage.
        /// </summary>
        /// <param name="playerName">The current name of the user in the game</param>
        /// <param name="playerHealth">The current health the user has in the game</param>
        /// <param name="playerWeapon">The current weapon the user is holding in the game</param>
        /// <param name="playerDamage">The current damage the user can do in the game with the weapon they have held</param>
        public Player(string playerName, int playerHealth, string playerWeapon, int playerDamage) : base(playerName, playerHealth, playerWeapon, playerDamage)
        { }

        /// <summary>
        /// Outputs the damage the enemy takes from the player in the particular room in the game.
        /// </summary>
        /// <param name="damage">The max damage the enemy can attack the player for</param>
        /// <param name="entityName">The name of the enemy attacking the player in the game</param>
        /// <param name="entityWeapon">The weapon the player is attacked with by the enemy in the game.</param>
        public override void TakeDamage(int damage, string entityName, string entityWeapon)
        {
            random = new Random();
            var weaponDamage = random.Next(0, damage);
            Console.WriteLine($"\n{entityName} attacks {Name} for {weaponDamage} with their {entityWeapon}");
            Health -= weaponDamage;
            Console.WriteLine($"\n{Name}: {Health} Health Remaining");
        }
        /// <summary>
        /// Allows the player to use a potion in the game. The player can only use a potion if they are alive, have health remaining under the max value (100) and have potions in their inventory.
        /// </summary>
        /// <param name="potions">The parameters of the potions the user has including name and heal amount</param>
        /// <param name="weapons">The parameters of the weapons the user has including the name and damage amount</param>
        /// <param name="items">The list of items the user has in their inventory including both weapons and potions</param>
        /// <param name="player">The parameters of the player including name, health, weapon name and damage</param>
        public void UsePotion(Potion potions, Weapon weapons, List<Item> items, Player player)
        {
            try
            {

                Console.WriteLine("Enter the name of the potion to use.");
                string itemName = Console.ReadLine().ToLower();
                var itemRemove = items.FirstOrDefault(potion => potions.Name.ToLower() == itemName.ToLower());
                if (itemRemove == null)
                {
                    Debug.Assert(itemRemove != null, "Error: Invalid Potion Item. You must type the name of a valid potion in your inventory.");
                    throw new Exception($"Item {itemName} not found in inventory. Please check the name of the potion you wanted to use.");
                }
                else if (Health >= 100)
                {
                    Debug.Assert(Health < 100, $"{Name} is already at full health. The potion has remained in {Name}'s inventory.");
                }
                else if (itemRemove.Name.ToLower() == weapons.Name.ToLower())
                {
                    Console.WriteLine($"{weapons.Name} is a weapon and cannot be consumed.");
                }
                else if (itemRemove.Name.ToLower() == "Fists".ToLower())
                {
                    Console.WriteLine($"Fists are a weapon and cannot be consumed.");
                }
                else if (Health > 100)
                {
                    Health = 100;
                    Console.WriteLine($"{Name} is at full health and is unable to use {potions.Name}");
                }
                else
                {
                    Health += potions.HealAmount;
                    if (Health > 100)
                    {
                        Health = 100;
                    }
                    Console.WriteLine($"{Name} used {itemRemove.Name} and healed for {potions.HealAmount} health.");
                    Console.WriteLine($"{Name} now has {Health} health.");
                    Console.WriteLine($"{itemRemove.Name} has been removed from {Name}'s inventory.");
                    items.Remove(itemRemove);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: Invalid Potion - {ex.Message}");
            }
        }
        /// <summary>
        /// Allows the player to equip the strongest weapon in their inventory. The player can only equip a weapon if they are alive and have other weapons in their inventory to challenge their currently equipped one.
        /// </summary>
        /// <param name="items">Access inventory items in particular the player's weapons stored in this list.</param>
        /// <param name="player">Access the player's currently equipped weapon through their parameters</param>
        /// <param name="weapon">Adding player's weaker weapon from their newly collected weapon into their inventory list.</param>
        public void EquipStrongestWeapon(List<Item> items, Player player, Weapon weapon)
        {
            var strongestWeapon = items.OfType<Weapon>().OrderByDescending(w => w.AverageDamage).FirstOrDefault();
            if (strongestWeapon != null)
            {
                if (strongestWeapon.AverageDamage > player.Damage)
                {
                    weapon.AddItem(player.Weapon, player.Damage, items);
                    Weapon = strongestWeapon.Name;
                    Damage = strongestWeapon.AverageDamage;
                    Console.WriteLine($"{Name} has equipped {strongestWeapon.Name} with {strongestWeapon.AverageDamage} damage.");
                    items.Remove(strongestWeapon);
                }

            }
        }
    }
}