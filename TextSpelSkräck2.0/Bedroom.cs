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
            Console.WriteLine(name);
            return base.InsideRoom();
        }

        protected override void FirstEntry()
        {
            Console.WriteLine("You walk through the door to the left");
            Console.WriteLine("Bedroom added to map");
            Console.WriteLine("\nPress any key to continue");
            Map.DiscoveredBedroom = true;
            Console.ReadKey();
            Console.Clear();

        }

        protected override int GoToCommand(string room)
        {
            switch(room)
            {
                case "main hall":
                case "mainhall":
                    return 1;

                case "basement":
                case "basement stairs":
                case "downstairs":
                case "right door":
                case "right":
                    if (!EventTriggers.BasementDoorIsLocked)
                        return 5;
                    else
                        Console.WriteLine("You try to open the door, however it appears to be locked.");
                    return id;

                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    return id;
            }
        }

        protected override void InspectCommand(string inspectedObject)
        {
            switch(inspectedObject)
            {
                case "cabinet":
                    InspectCabinet();
                    break;

                case "bed":
                    InspectBed();
                    break;

                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    break;
            }
        }

        protected override void PickUpCommand(string item)
        {
            switch(item)
            {
                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    break;
            }
        }

        protected override void UseCommand(string item)
        {
            switch(item)
            {
                case "basement key":
                case "key":
                case "item":
                    UseKey();
                    break;

                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    break;
            }
        }

        void InspectCabinet()
        {
            Console.WriteLine("The cabinet is made out of old planks, although they appear to have aged much better \n" +
                        "compared to the rest of the house, probably because it is made by a different kind of tree. \n" +
                        "The cabinet door has been torn out together with the hinges. Whatever caused this, it has an \n" +
                        "incredible amount of strength.");
        }

        void InspectBed()
        {
            Console.WriteLine("The bed appears to be damp and molded, with multiple stains covering the mattress. The \n" +
                        "pillow has been torn up, revealing the few feathers still left inside. The cover has been \n" +
                        "moved to the side, as if someone just woke up. Although somewhat molded, the cover \n" +
                        "appears to be in much better shape than the rest of the bed.");
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
            Console.WriteLine("The first thing you see is a bed right in front of you. The walls, unlike the rest of the house are \n" +
                "covered with wallpaper, and appear to be newer than the rest of the house, as if someone \n" +
                "had been renovating the room recently. next to the bed there is a cabinet with the door torn \n" +
                "out, completely empty. To the right of the room there is another door, that contrary to the rest \n" +
                "of the room is even more molded and damp than the rest of the house.");
        }
    }
}
