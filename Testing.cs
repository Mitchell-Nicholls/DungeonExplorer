using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DungeonExplorer
{
    public class Testing
    {
        public Testing()
        {

        }
        public void inRange(int testingInput, int minTestingRange, int maxTestingRange) 
        {
            Debug.Assert(testingInput > minTestingRange && testingInput < maxTestingRange, $"Error: Invalid Input. You must type a number between {minTestingRange + 1} and {maxTestingRange - 1} to proceed.");
        }
        public void nullOrEmpty(string testingInput, int minTestingRange, int maxTestingRange)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(testingInput), $"Error: Null or empty input. You must enter a valid number between {minTestingRange + 1} and {maxTestingRange - 1} to proceed through the game.");
        }
    }
}
