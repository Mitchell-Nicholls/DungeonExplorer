using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using System.Media;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private Player enemy;
        public Game()
        {
            // Initialize the game with one room and one player
            player = new Player("Mitchell", 100);
            enemy = new Player("Goblins", 30);
            currentRoom = new Room("Dungeon Entrance \n\nAn eary aura roams through the path in front of you with you being able to sense the danger up ahead.");
            Console.WriteLine($"Player Name: {player.Name} \tPlayer Health: {player.Health} \tStarting Room: {currentRoom.GetDescription()} ");
            System.Threading.Thread.Sleep(1000);
        }
        public void Start()
        {
            bool playing = true;
            Random random = new Random();

            Console.WriteLine("\nHung on opposite walls are a sword and a bow with a quiver.\nDo you choose the bow (type bow) or the sword (type sword)? (You can only pick one.)");
            string weaponChoice = Console.ReadLine().ToLower();
            // Choice 1 Option 1/2

            try
            {
                if (weaponChoice == "bow")
                {
                    Console.WriteLine($"{player.Name} has chosen the {weaponChoice}.");
                    player.PickUpItem("Bow");
                    player.PickUpItem("Unlimited Healing Potion");
                    Console.WriteLine($"{player.Name}'s Inventory: {player.InventoryContents()}");
                }
                // Choice 1 Option 2/2
                else if (weaponChoice == "sword")
                {
                    Console.WriteLine($"{player.Name} has chosen the {weaponChoice}.");
                    player.PickUpItem("Sword");
                    player.PickUpItem("Unlimited Healing Potion");
                    Console.WriteLine($"{player.Name}'s Inventory: {player.InventoryContents()}");
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            // Exception generating user's weapon if invalid input.
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Invalid weapon. Generating random weapon for {player.Name}...");
                int randomWeapon = random.Next(1, 3);
                if (randomWeapon == 1)
                {
                    weaponChoice = "bow";
                    Console.WriteLine($"{player.Name} chose the {weaponChoice}.");
                    player.PickUpItem("Bow");
                    player.PickUpItem("Unlimited Healing Potion");
                    Console.WriteLine($"{player.Name}'s Inventory: {player.InventoryContents()}");
                }
                else
                {
                    weaponChoice = "sword";
                    Console.WriteLine($"{player.Name} chose the {weaponChoice}.");
                    player.PickUpItem("Sword");
                    player.PickUpItem("Unlimited Healing Potion");
                    Console.WriteLine($"{player.Name}'s Inventory: {player.InventoryContents()}");
                }
            }

            Console.WriteLine($"\nA group of goblin enemies holding clubs head towards {player.Name}. ");
            while (playing)
            {
                // Code your playing logic here
                try
                {
                    Console.WriteLine($"Do you heal (type h or heal) yourself or attack (type a or attack) the goblins?");
                    string choice = Console.ReadLine().ToLower();
                    // Choice 2 Option 1/2
                    if (choice == "heal" || choice == "h")
                    {
                        if (player.Health < 100)
                        {
                            int HealPoint = random.Next(10, 26);
                            Console.WriteLine($"{player.Name} used a health potion and healed {HealPoint} health");
                            Console.WriteLine($"{player.Name}'s health:{player.Health += HealPoint}");
                        }
                        if (player.Health > 100)
                        {
                            Console.WriteLine($"{player.Name}'s Health exceeded 100. {player.Health} set to 100...");
                            player.Health = 100;
                            throw new Exception("User is at full health. Unable to use heal...");

                        }
                        if (enemy.Health > 0)
                        {
                            int enemyAttack = random.Next(0, 12);
                            Console.WriteLine($"{enemy.Name} dealt {enemyAttack} damage");
                            Console.WriteLine($"{player.Name}'s health:{player.Health -= enemyAttack}");

                            if (player.Health <= 0)
                            {
                                Console.WriteLine($"{player.Name}'s health has been lost. You lose.");
                            }
                        }

                    }




                    // Choice 2 Option 2/2
                    if (choice == "attack" || choice == "a")
                    {
                        Console.WriteLine($"\n{player.Name} attacked the goblins with the {weaponChoice}.");
                        // Option for Sword
                        if (weaponChoice == "sword")
                        {
                            int swordDamage = random.Next(0, 12);
                            Console.WriteLine($"{player.Name} dealt {swordDamage} damage");
                            enemy.Health -= swordDamage;
                            if (enemy.Health <= 0)
                            {
                                enemy.Health = 0;
                            }
                        }
                        // Option for Bow
                        else if (weaponChoice == "bow")
                        {
                            int bowDamage = random.Next(0, 6);
                            Console.WriteLine($"{player.Name} dealt {bowDamage * 2} damage");
                            enemy.Health -= bowDamage * 2;
                            if (enemy.Health <= 0)
                            {
                                enemy.Health = 0;
                            }
                        }

                        Console.WriteLine($"{enemy.Name}'s Health:{enemy.Health}");
                        if (enemy.Health <= 0)
                        {
                            Console.WriteLine($"{enemy.Name} are defeated. You win.");
                            int Coin = random.Next(25, 100);
                            string enemyWeapon = "Goblin Club";
                        
                            Console.WriteLine($"{player.Name} earned {Coin} coins.");
                        PickupChoice:
                            Console.WriteLine($"{enemy.Name} dropped a {enemyWeapon}.\nWould you like to pick it up?");
                            string weaponPickUp = Console.ReadLine();
                            if (weaponPickUp == "yes")
                            {
                                Console.WriteLine($"{player.Name} picked up the {enemyWeapon}.");
                                player.PickUpItem(enemyWeapon);
                                Console.WriteLine($"Player:{player.Name} \tHealth:{player.Health} \tInventory:{player.InventoryContents()} \tCoin Balance:{Coin}");
                                Console.WriteLine("To be Continued...");
                                break;
                            }
                            else if (weaponPickUp == "no")
                            {
                                Console.WriteLine($"{player.Name} did not pick up the {enemyWeapon}");
                                Console.WriteLine($"Player:{player.Name} \tHealth:{player.Health} \tInventory:{player.InventoryContents()} \tCoin Balance:{Coin}");
                                Console.WriteLine("To be Continued...");
                                break;
                            }
                            else
                            {
                                goto PickupChoice;
                            }
                        }
                        // Enemy Attack
                        else if (enemy.Health > 0)
                        {
                            int enemyAttack = random.Next(0, 12);
                            Console.WriteLine($"{enemy.Name} dealt {enemyAttack} damage");
                            Console.WriteLine($"{player.Name}'s health:{player.Health -= enemyAttack}");
                        }
                        // Player Death
                        else if (player.Health <= 0)
                        {
                            Console.WriteLine($"{player.Name} has been defeated. You lose.");
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException("Error: Unacceptable Input. You can only attack or heal.");
                        }
                    }

                }
                // Exception for user's options (attack or heal)
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);

                }

                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
             
            }

        }
    }
}
