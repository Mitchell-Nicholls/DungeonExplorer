using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Statistics
    {
        int i = 0;  

        /// <summary>
        /// The method is referenced for each enemy in the dungeon the user defeats adding a score each time upping in value for the difficulty of the monster
        /// </summary>
        /// <param name="score">The score assigned for each monster.</param>
        public void monsterDefeat(int score)
        {
            i += score;
            Console.WriteLine($"Score: {i}");
        }
        /// <summary>
        /// This method is called for when the player is defeated. This will be displayed in the console based off the monsterDefeat method.
        /// </summary>
        public void DisplayScore()
        {
            Console.WriteLine($"Current Score: {i}");
        }
    }
}
