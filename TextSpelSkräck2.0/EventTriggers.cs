using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal static class EventTriggers
    {
        // contains booleans that are not exclusive to one room, for example basement door gets locked while in storage/cell
        static bool basementDoorIsLocked;
        static bool isCarryingEllen;
        static bool ellenIsAtStairs;
        static bool secretPassageIsClosed;
        
        static EventTriggers()
        {
            basementDoorIsLocked = true;
            isCarryingEllen = false;
            ellenIsAtStairs = false;
            secretPassageIsClosed = true;

        }

        public static bool BasementDoorIsLocked { get { return basementDoorIsLocked; } set { basementDoorIsLocked = value; } }
        public static bool IsCarryingEllen { get { return isCarryingEllen; } set { isCarryingEllen = value; } }
        public static bool EllenIsAtStairs { get { return ellenIsAtStairs; } set { ellenIsAtStairs = value;} }
        public static bool SecretPassageIsClosed { get { return secretPassageIsClosed; } set { secretPassageIsClosed = value;} }
    }
}
