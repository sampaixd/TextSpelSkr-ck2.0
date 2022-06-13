using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal static class EventTriggers
    {
        // contains booleans that are not exclusive to one room, for example basement door gets locked while in storage/cell, 
        // and is used for traversal within the basement stairs as well
        static bool basementDoorIsLocked;
        static EventTriggers()
        {
            basementDoorIsLocked = true;
        }

        public static bool BasementDoorIsLocked { get { return basementDoorIsLocked; } set { basementDoorIsLocked = value; } }
    }
}
