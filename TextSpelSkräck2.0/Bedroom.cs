using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal class Bedroom : Room
    {
        
        public Bedroom() : base("Bedroom", 2)
        { }

        public override int InsideRoom()
        {
            if (!Map.DiscoveredBedroom)
                FirstEntry();
            
            while (true)
            {
                string userInput = Console.ReadLine();
                userInput = userInput.ToLower();
                Console.Clear();
                switch (userInput)
                {
                    case "go to main hall":
                    case "go to mainhall":
                        return 1;

                    case "use basement key":
                    case "use key":
                    case "use item":
                        UseKey();
                        break;

                    default:
                        InsideRoomBaseSwitch(userInput);
                        break;
                }
            }
        }

        protected override void FirstEntry()
        {
            throw new NotImplementedException();
        }

        void UseKey()
        {
            if (Inventory.IsPickedUp(0) && !Inventory.IsConsumed(0))
            {
                Console.WriteLine("The key fits into the lock perfectly, however the door remains stuck in place. After putting \n" +
                            "enough force into the rotten wood, you manage to push it open with a creaking sound. \n" +
                            "Looking through the door, you see an old wooden staircase, accompanied by complete \n" +
                            "darkness as well as the faint smell of coal coming from below. Down at the bottom of the \n" +
                            "staircase, you can hear a faint but rasping breathing. Could it be Ellen?");
                EventTriggers.BasementDoorIsLocked = false;
                Inventory.ConsumeItem(0);
            }
            else if (Inventory.IsConsumed(0) && !EventTriggers.BasementDoorIsLocked)
            {
                Console.WriteLine("You have already used the key");
            }

            else if (Inventory.IsConsumed(0))
            {
                Console.WriteLine("The key that you had left in the keyhole of the basement door has disappeared. Looking \n" +
                    "around on the floor there is no trace of the key. Someone, or rather something must have \n" +
                    "taken the key while you were down there.");
            }

            else
            {
                Console.WriteLine("You currently do not have the key needed for this door");
            }
        }

        protected override void LookAround()
        {
            throw new NotImplementedException();
        }
    }
}
