using System;
using System.Diagnostics;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            // Initialize the game with one room and one player
            player = new Player("Mitchell", 100);
            currentRoom = new Room("Dungeon Entrance \n\nAn eary aura roams through the path in front of you with you being able to sense the danger up ahead.");
            Console.WriteLine($"Player Name: {player.Name} \tPlayer Health: {player.Health} \tStarting Room: {currentRoom.GetDescription()} ");
            System.Threading.Thread.Sleep(1000);
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;

            while (playing)
            {
                // Code your playing logic here

                Console.WriteLine("\nHung on opposite walls are a sword and a bow with a quiver.\nDo you choose the bow (type 1) or the sword (type 2)? (You can only pick one.)");
                try
                {
                    string weaponChoice = Console.ReadLine().ToLower();
                    if (weaponChoice == "bow")
                    {
                        //throw new ArgumentOutOfRangeException("Value Bow is invalid.");
                        Console.WriteLine($"{player.Name} has chosen the BOW");
                        player.PickUpItem("Bow");
                        System.Threading.Thread.Sleep(2000);
                        Console.Write($"Player Inventory: {player.InventoryContents()}");

                        Console.WriteLine("");

                        break;
                    }
                    else if (weaponChoice == "sword")
                    {
                        Console.WriteLine($"{player.Name} has chosen the SWORD.");
                        player.PickUpItem("Sword");
                        Console.WriteLine($"Player Inventory: {player.InventoryContents()}");

                        Console.WriteLine("");
                        break;
                    }
                    if (string.IsNullOrWhiteSpace(weaponChoice))
                    {
                        throw new ArgumentNullException(nameof(weaponChoice), "Cannot be empty or null. Enter a valid number either 1 for sword or 2 for bow.");
                    }
                    if (weaponChoice != "sword" || weaponChoice != "bow")
                    {
                        throw new ArgumentOutOfRangeException(nameof (weaponChoice), "This input is Invalid. Values string or bow are available to advance." );
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
            }
        }
    }
}
