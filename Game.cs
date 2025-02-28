using System;
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
            // Change the playing logic into true and populate the while loop
            //bool weaponOption = true;
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
                    Console.WriteLine($"{player.Name}'s Inventory: {player.InventoryContents()}");
                        //break;
                    //int bowDamage = random.Next(0, 20);
                }
                else if (weaponChoice == "sword")
                {
                    Console.WriteLine($"{player.Name} has chosen the {weaponChoice}.");
                    player.PickUpItem("Sword");
                    Console.WriteLine($"{player.Name}'s Inventory: {player.InventoryContents()}");
                        //break;
                    //int swordDamage = random.Next(0, 12);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Invalid weapon. Generating random weapon for {player.Name}...");
                int randomWeapon = random.Next(1, 3);
                if (randomWeapon == 1)
                {
                    weaponChoice = "bow";
                    Console.WriteLine($"{player.Name} chose the {weaponChoice}.");
                }
                else
                {
                    weaponChoice = "sword";
                    Console.WriteLine($"{player.Name} chose the {weaponChoice}.");
                }
            }

            Console.WriteLine($"\nA group of goblin enemies holding clubs head towards {player.Name}. ");
            //Console.WriteLine($"Player Dealt {PlayerAttack} damage");
            while (playing)
            {
                // Code your playing logic here
                try
                {

                    Console.WriteLine($"Do you heal yourself or attack the goblins?");
                    string choice = Console.ReadLine().ToLower();
                    // Choice 2 Option 1/2
                    if (choice == "heal")
                    {
                        if (player.Health < 100)
                        {
                            int HealPoint = random.Next(10, 26);
                            Console.WriteLine($"{player.Name} used a health potion and healed {HealPoint} health");
                            Console.WriteLine($"{player.Name}'s health:{player.Health += HealPoint}");
                            if (player.Health > 100)
                            {
                                player.Health = 100;
                                throw new Exception($"Health cannot exceed 100. {player.Name}'s health set to {player.Health}.");
                            }

                        }
                        else
                        {
                            Console.WriteLine($"{player.Name} is at full health. Unable to heal anymore.");
                        }
                        if (enemy.Health > 0)
                        {
                            int enemyAttack = random.Next(0, 12);
                            Console.WriteLine($"{enemy.Name} dealt {enemyAttack} damage");
                            Console.WriteLine($"{player.Name}'s health:{player.Health -= enemyAttack}");
                        }
                        else if (player.Health <= 0)
                        {
                            Console.WriteLine($"{player.Name}'s health has been lost. You lose.");
                        }

                    }
                    // Choice 2 Option 2/2
                    if (choice == "attack")
                    {
                        Console.WriteLine($"\n{player.Name} attacked the goblins with the {weaponChoice}.");
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
                        else if (weaponChoice == "bow")
                        {
                            int bowDamage = random.Next(0, 6);
                            Console.WriteLine($"{player.Name} dealt {bowDamage*2} damage");
                            enemy.Health -= bowDamage*2;
                            if (enemy.Health <= 0)
                            {
                                enemy.Health = 0;
                            }
                        }

                        Console.WriteLine($"{enemy.Name}'s Health:{enemy.Health}");
                        if (enemy.Health <= 0)
                        {
                            Console.WriteLine($"{enemy.Name} are defeated. You win.");
                            break;
                        }
                        else if (enemy.Health > 0)
                        {
                            int enemyAttack = random.Next(0, 12);
                            Console.WriteLine($"{enemy.Name} dealt {enemyAttack} damage");
                            Console.WriteLine($"{player.Name}'s health:{player.Health -= enemyAttack}");
                        }
                        else if (player.Health <= 0)
                        {
                            Console.WriteLine($"{player.Name}'s health has been lost. You lose.");
                        }
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Error: Unacceptable Input. You can only attack or heal.");
                    }
                }


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
