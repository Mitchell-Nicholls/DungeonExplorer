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

        public void AddScore(int score)
        {
            i += score;
            Console.WriteLine($"Score: {i}");
        }
        
    }
}
