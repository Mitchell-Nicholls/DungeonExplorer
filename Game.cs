using System;
using System.Diagnostics;
using System.Xml;
namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private Player enemy;
        private Testing testing;
        public double baseWeaponAverage = (1.0 + 12.0) / 2.0;
        public double clubAverage = (3.0 + 18.0) / 2.0;
        
        /// <summary>Initiates the game with one room and one Player.
        /// </summary>
        public Game()
        {
            player = new Player("Mitchell", 100);
            enemy = new Player("Goblins", 30);
            testing = new Testing("Error: Invalid Weapon Choice:", "User must type bow or sword to proceed or generate random weapon.");
            currentRoom = new Room("Dungeon Entrance", $"An eary aura roams through the path in front of you with you being able to sense the danger up ahead.");
            Console.WriteLine($"Player Name: {player.Name} \tPlayer Health: {player.Health} \tStarting Room: {currentRoom.GetRoomName()} \n\nRoom Description: {currentRoom.GetDescription()} ");
            System.Threading.Thread.Sleep(1000);
        }
        /// <summary>
        /// Structure of the game for the user to interact with for different outcomes to occur
        /// </summary>
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
                    Console.WriteLine($"{player.Name} chose the {weaponChoice}.\tAverage Damage: {baseWeaponAverage}");
                    Console.WriteLine($"{player.Name} also acquired a healing potion with unlimited uses.");
                    player.PickUpItem("Bow");
                    player.PickUpItem("Unlimited Healing Potion");
                    Console.WriteLine($"{player.Name}'s Inventory: {player.GetInventoryContents()}");
                }
                // Choice 1 Option 2/2
                else if (weaponChoice == "sword")
                {
                    Console.WriteLine($"{player.Name} chose the {weaponChoice}.\tAverage Damage: {baseWeaponAverage}");
                    Console.WriteLine($"{player.Name} also acquired a healing potion with unlimited uses.");
                    player.PickUpItem("Sword");
                    player.PickUpItem("Unlimited Healing Potion");
                    Console.WriteLine($"{player.Name}'s Inventory: {player.GetInventoryContents()}");
                }
                else
                {
                    Debug.Assert(weaponChoice == "sword" || weaponChoice == "bow", $"{testing.TestingName()} {testing.DebugMessage()}");
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
                    Console.WriteLine($"{player.Name} chose the {weaponChoice}.\tAverage Damage: {baseWeaponAverage}");
                    Console.WriteLine($"{player.Name} also acquired a healing potion with unlimited uses.");
                    player.PickUpItem("Bow");
                    player.PickUpItem("Unlimited Healing Potion");
                    Console.WriteLine($"{player.Name}'s Inventory: {player.GetInventoryContents()}");
                }
                else
                {
                    weaponChoice = "sword";
                    Console.WriteLine($"{player.Name} chose the {weaponChoice}.\tAverage Damage: {baseWeaponAverage}");
                    Console.WriteLine($"{player.Name} also acquired a healing potion with unlimited uses.");
                    player.PickUpItem("Sword");
                    player.PickUpItem("Unlimited Healing Potion");
                    Console.WriteLine($"{player.Name}'s Inventory: {player.GetInventoryContents()}");
                }
            }
            
            Console.WriteLine($"\nA group of goblin enemies holding clubs head towards {player.Name}.\n{player.Name}: {player.Health} Health\n{enemy.Name}: {enemy.Health} Health");
            while (playing)
            {
                // Code your playing logic here
                try
                {
                    testing = new Testing("Error: Invalid Battle Choice:", "User must type attack (or a) or heal (or h) to proceed the battle.");
                    Console.WriteLine($"\nDo you heal (type h or heal) yourself or attack (type a or attack) the goblins?\nTip: Type view for user inventory and current room description.");
                    string choice = Console.ReadLine().ToLower();
                    if (choice == "view")
                    {
                        Console.WriteLine($"\nRoom Name:{currentRoom.GetRoomName()}\nRoom Description:{currentRoom.GetDescription()}\nInventory:{player.GetInventoryContents()}");
                        continue;
                    }
                    // Choice 2 Option 1/2
                    if (choice == "heal" || choice == "h")
                    {
                        if (player.Health < 100)
                        {
                            int HealPoint = random.Next(10, 26);
                            Console.WriteLine($"{player.Name} used a health potion and healed {HealPoint} health");
                            player.Health += HealPoint;
                            if (player.Health > 100)
                            {
                                player.Health = 100;
                                Console.WriteLine($"{player.Name}'s Health: {player.Health}");
                            }
                        }
                        else if (player.Health >= 100)
                        {
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
                    else if (choice == "attack" || choice == "a")
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
                            Console.WriteLine($"{player.Name} dealt {bowDamage} damage");
                            enemy.Health -= bowDamage;
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
                            testing = new Testing("Error: Invalid Option:", $"User must type yes or no to picking up the {enemyWeapon}. (or y for yes and n for no)");
                            Console.WriteLine($"{player.Name} earned {Coin} coins.");
                        PickupChoice:
                            Console.WriteLine($"{enemy.Name} dropped a {enemyWeapon}: Average Damage: {clubAverage} \nCurrent Weapon: {weaponChoice}: Average Damage: {baseWeaponAverage}\nWould you like to pick it up? \n(type 'yes' or 'y' for yes or 'no' or 'n' for no)");
                            string weaponPickUp = Console.ReadLine();
                            if (weaponPickUp == "yes" || weaponPickUp == "y")
                            {
                                Console.WriteLine($"{player.Name} picked up the {enemyWeapon}.");
                                player.PickUpItem(enemyWeapon);
                                Console.WriteLine($"Player:{player.Name} \tCurrent Health:{player.Health} \tCurrent Inventory:{player.GetInventoryContents()} \tCoin Balance:{Coin}");
                                Console.WriteLine("To be Continued...");
                                break;
                            }
                            else if (weaponPickUp == "no" || weaponPickUp == "n")
                            {
                                Console.WriteLine($"{player.Name} did not pick up the {enemyWeapon}");
                                Console.WriteLine($"Player:{player.Name} \tCurrent Health:{player.Health} \tCurrent Inventory:{player.GetInventoryContents()} \tCoin Balance:{Coin}");
                                Console.WriteLine("To be Continued...");
                                break;
                            }
                            else
                            {
                                Debug.Assert(weaponChoice == "yes" || weaponChoice == "no" || weaponChoice == "n" || weaponChoice == "y", $"{testing.TestingName()} {testing.DebugMessage()}");
                                goto PickupChoice;
                            }
                        }
                        // Enemy Attack
                        if (enemy.Health > 0)
                        {
                            int enemyAttack = random.Next(0, 12);
                            Console.WriteLine($"{enemy.Name} dealt {enemyAttack} damage");
                            Console.WriteLine($"{player.Name}'s health:{player.Health -= enemyAttack}");
                        }
                        // Player Death
                        if (player.Health <= 0)
                        {
                            Console.WriteLine($"{player.Name} has been defeated. You lose.");
                            break;
                        }
                    }
                    else
                    {
                        Debug.Assert(choice == "view" || choice == "attack" || choice == "a" || choice == "heal" || choice == "h", $"{testing.TestingName()} {testing.DebugMessage()}");
                        throw new ArgumentOutOfRangeException("Unacceptable Input. You can only attack or heal.");
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
