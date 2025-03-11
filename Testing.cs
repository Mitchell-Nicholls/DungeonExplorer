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
        private string debugMessage;
        private string debugName;
        
        /// <summary>
        /// This Method will return the name of the error along with the message for it.
        /// </summary>
        /// <param name="debugName">the name of the debug message</param>
        /// <param name="debugMessage">the message assigned for the name of the debug</param>
        /// <returns>the debug message and name</returns>
        public Testing(string debugName, string debugMessage)
        {
            this.debugName = debugName;
            this.debugMessage = debugMessage;
        }
        /// <summary>
        /// Returns the name of the debug
        /// </summary>
        /// <returns>Name of the debug</returns>
        public string TestingName()
        {
            return debugName;
        }
        /// <summary>
        /// Returns the value of the debug message
        /// </summary>
        /// <returns>The debug Message</returns>
        public string DebugMessage()
        {
            return debugMessage;
        }
    }
}
