using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Xml;
namespace DungeonExplorer
{
    internal class Game
    {
        Inventory inventory;
        Potion potion;
        //Key Key;
        private List<Monster> monsters;
        List<Item> playerItems = new List<Item>();
        private Creature currentEnemy;
        private Player player;
        private Testing testing;
        GameMap gamemap;
        Weapon weapon;

        /// <summary>Initiates the game with one room and one Player.
        /// </summary>
        public Game()
        {
            Random random = new Random();
            potion = new Potion("Healing Potion", 50);
            weapon = new Weapon("Wooden Plank", random.Next(13, 21));
            inventory = new Inventory();
            gamemap = new GameMap();
            Monster enemy_1 = new Goblin("Goblin", 20, "Dagger", 5);
            Monster enemy_2 = new Goblin("Goblin Jockey", 20, "Wooden Plank", 7);
            Monster enemy_3 = new Goblin("Giant Goblin", 25, "Pipe", 9);
            Monster enemy_4 = new Goblin("Goblin Zombie", 30, "Fists", 10);
            Monster enemy_5 = new Goblin("Goblin Warrior", 30, "Sword", 12);
            Monster enemy_6 = new Goblin("Goblin Sorcerer", 30, "Magic Staff", 14);
            Monster boss = new Boss("Goblin King", 50, "Magic Staff", 17);
            monsters = new List<Monster> { enemy_1, enemy_2, enemy_3, enemy_4, enemy_5, enemy_6, boss };

            player = new Player("Mitchell", 100, "Fists", 12);
            testing = new Testing("Error: Invalid Weapon Choice:", "User must type bow or sword to proceed or generate random weapon.");

            currentEnemy = monsters[0];
            gamemap.CreateMap(5);
            Console.WriteLine($"\n{monsters.Count} monsters in the dungeon.\tObjective: Survive");
        }
        /// <summary>
        /// Structure of the game for the user to interact with for different outcomes to occur
        /// </summary>
        public void Start()
        {
            Console.WriteLine("\nThe player starts with 3 healing potions on their journey.\n");
            potion.AddItem(potion.Name, potion.HealAmount, playerItems);
            potion.AddItem(potion.Name, potion.HealAmount, playerItems);
            potion.AddItem(potion.Name, potion.HealAmount, playerItems);
            inventory.GetInventoryContents(playerItems);
            gamemap.CurrentRoom(0);
            Thread.Sleep(5000);

            while (player.IsAlive && currentEnemy.IsAlive)
            {

                Thread.Sleep(3500);
                Console.Clear();
                Console.WriteLine("Room 1");
                player.DisplayInfo();
                Console.WriteLine();
                currentEnemy.DisplayInfo();
                PlayerTurn(0, true);
            }

            currentEnemy = monsters[1];
            gamemap.CurrentRoom(1);
            Console.WriteLine();
            while (player.IsAlive && currentEnemy.IsAlive)
            {
                Thread.Sleep(3500);
                Console.Clear();
                Console.WriteLine("Room 2");
                player.DisplayInfo();
                Console.WriteLine();
                currentEnemy.DisplayInfo();

                PlayerTurn(1, false);
            }
            currentEnemy = monsters[2];
            gamemap.CurrentRoom(2);
            Console.WriteLine();
            while (player.IsAlive && currentEnemy.IsAlive)
            {
                Thread.Sleep(3500);
                Console.Clear();
                Console.WriteLine("Room 3");
                player.DisplayInfo();
                Console.WriteLine();
                currentEnemy.DisplayInfo();
                PlayerTurn(2, false);
            }
            currentEnemy = monsters[3];
            gamemap.CurrentRoom(3);
            while (player.IsAlive && currentEnemy.IsAlive)
            {
                Thread.Sleep(3500);
                Console.Clear();
                Console.WriteLine("Room 4");
                player.DisplayInfo();
                Console.WriteLine();
                currentEnemy.DisplayInfo();
                PlayerTurn(3, false);
            }
            currentEnemy = monsters[4];
            gamemap.CurrentRoom(4);
            while (player.IsAlive && currentEnemy.IsAlive)
            {
                Thread.Sleep(3500);
                Console.Clear();
                Console.WriteLine("Room 5");
                player.DisplayInfo();
                Console.WriteLine();
                currentEnemy.DisplayInfo();
                PlayerTurn(4, false);
            }
            currentEnemy = monsters[5];
            gamemap.CurrentRoom(5);
            while (player.IsAlive && currentEnemy.IsAlive)
            {
                Thread.Sleep(3500);
                Console.Clear();
                Console.WriteLine("Room 6");
                player.DisplayInfo();
                Console.WriteLine();
                currentEnemy.DisplayInfo();
                PlayerTurn(5, true);
            }
            currentEnemy = monsters[6];
            gamemap.CurrentRoom(6);
            while (player.IsAlive && currentEnemy.IsAlive)
            {
                Thread.Sleep(3500);
                Console.Clear();
                Console.WriteLine("Room 7");
                Console.WriteLine();
                player.DisplayInfo();
                Console.WriteLine();
                currentEnemy.DisplayInfo();
                PlayerTurn(6, true);

                weapon.AddItem(weapon.Name, weapon.AverageDamage);
                inventory.GetInventoryContents(playerItems);

            }
            Console.WriteLine("You have defeated the dungeon. Congratulations, your adventure is complete.");
        }
        private void PlayerTurn(int roomNumber, bool hasKey)
        {
            Console.WriteLine("What would the player like to do?");
            Console.WriteLine("1. Attack\n2. Heal\n3. View Inventory\n4. View Current Room\n5. Go to next room");
            string choice = Console.ReadLine();
            try
            {
                if (choice == "1")
                {
                    Console.WriteLine("Player uses Attack");
                    currentEnemy.TakeDamage(player.Damage, player.Name, player.Weapon);
                    player.TakeDamage(currentEnemy.Damage, currentEnemy.Name, currentEnemy.Weapon);
                    if (currentEnemy.IsDead)
                    {
                        Console.WriteLine($"{currentEnemy.Name} is dead. You win.");
                        potion.AddItem(potion.Name, potion.HealAmount, playerItems);
                        weapon.AddItem(weapon.Name, weapon.AverageDamage, playerItems);
                        player.EquipStrongestWeapon(playerItems, player, weapon);
                        inventory.GetInventoryContents(playerItems);
                        hasKey = true;
                        if (hasKey)
                        {
                            Console.WriteLine($"{player.Name} unlocks the door and advances to the next room.");
                        }
                    }
                    if (player.IsDead)
                    {
                        Console.WriteLine($"{player.Name} died in battle. You lose.");
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Player uses Heal.");
                    inventory.GetPotionsInInventory(playerItems);
                    player.UsePotion(potion, weapon, playerItems, player);
                    player.TakeDamage(currentEnemy.Damage, currentEnemy.Name, currentEnemy.Weapon);
                    if (player.IsDead)
                    {
                        Console.WriteLine($"{player.Name} died while healing. You lose.");
                    }
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Player views inventory.");
                    inventory.GetInventoryContents(playerItems);
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Player chooses to view their current room.");
                    gamemap.CurrentRoom(roomNumber);
                }
                else if (choice == "5" && !hasKey)
                {
                    Console.WriteLine($"The Key is required to advance. You must defeat the {currentEnemy.Name} to receive the key.");
                }
                else if (choice == "5" && hasKey)
                {
                    Console.WriteLine($"The door is already unlocked but you must defeat the {currentEnemy.Name} blocking the path to the door.");
                }
                else if (string.IsNullOrWhiteSpace(choice))
                {
                    Debug.Assert(choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5", $"Error: Null or empty choice {choice}. User must type a number between 1-5.");

                    throw new ArgumentNullException($"Error: Null or Empty Option. You must type a number between 1-5 to proceed");

                }
                else
                {
                    Debug.Assert(choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5", $"Error: Invalid Choice {choice}. User must type a number between 1-5.");
                    throw new ArgumentOutOfRangeException($"Error: Unacceptable Option {choice}. You must enter only one number from 1-5");
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
    }
}