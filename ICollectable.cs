using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal interface ICollectable
    {
        /// <summary>
        /// Adds the item type to the player's inventory list
        /// </summary>
        /// <param name="itemName">Name of the item to add to the inventory</param>
        /// <param name="itemStat">Status effect of the item to add to the inventory</param>
        void AddItem(string itemName, int itemStat);
    }
}
