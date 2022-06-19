using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal class Storage : Room
    {
        public Storage() : base ("Storage", 7 ) 
        { }

        public override int InsideRoom()
        {
            if (!Map.DiscoveredStorage)
                FirstEntry();

            return base.InsideRoom();
        }
        protected override void FirstEntry()
        {
            Console.WriteLine("You walk through the left corridor, leading you into what appears to be a storage room.");
            Console.WriteLine("Storage added to map");
            Console.WriteLine("\nPress any key to continue");
            Map.DiscoveredStorage = true;
            Console.ReadKey();
            Console.Clear();
            if (EventTriggers.EllenIsAtStairs)
            {
                Console.WriteLine("As you walk into the storage, you suddenly hear a scream coming from the basement stairs, \n" +
                                "followed by the sound of a door violently shutting. That scream sounded just like Ellen. ");
                Console.WriteLine("\nPress any key to continue");
                EventTriggers.EllenIsAtStairs = false;
                EventTriggers.BasementDoorIsLocked = true;
                Console.ReadKey();
                Console.Clear();
            }
            Console.ReadKey();
            Console.Clear();
        }

        protected override int GoToCommand(string room)
        {
            switch(room)
            {
                case "cell":
                    return 6;

                case "corridor":
                case "secret":
                case "passage":
                case "secret passage":
                case "lobby":
                    if (!EventTriggers.SecretPassageIsClosed)
                        return 11;
                    else
                        Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
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
                case "note":
                case "paper":
                case "document":
                case "piece of paper":
                    PickUpNote();
                    break;

                case "inspect crates":
                case "inspect boxes":
                    InspectBoxes();
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
                case "note":
                case "paper":
                case "document":
                case "piece of paper":
                    PickUpNote();
                    break;

                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    break;
            }
        }

        protected override void UseCommand(string item)
        {

            switch (item)
            {
                case "gun":
                case "pistol":
                case "weapon":
                case "firearm":
                    UseGun();
                    break;
                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    break;
            }
        }

        void PickUpNote()
        {
            if (!DocumentManager.IsPickedUp(5))
            {
                Console.WriteLine("You walk up to the note and pick it up. The content of the note appears to have been written \n" +
                                "in a hurry, as well as somewhat weird grammar with some large letters at places where they \n" +
                                "should not be.");
                Console.WriteLine("\n" + DocumentManager.Content(5));
                Console.WriteLine("\nNotes about 'it' added to documents");
                Console.WriteLine("\nPress any key to continue");
                DocumentManager.UnlockDocument(5);
                Console.ReadKey();
                Console.Clear();
            }
            else
                Console.WriteLine("You have already picked up the note");
        }

        void InspectBoxes()
        {
            Console.WriteLine("There are plenty of crates lying around in the room, filled with seemingly random items.");

            if (!Inventory.IsPickedUp(4))
            {
                Console.WriteLine("In one of the crates, you notice a small box lying there. The box has targets painted on all \n" +
                    "sides, and is stuck in place, making you unable to pick it up. You try breaking the box, \n" +
                    "however it stands strong without even a little scratch.");
            }
        }

        void UseGun()
        {
            if (!Inventory.IsPickedUp(4) && Inventory.IsPickedUp(3))
            {
                Console.WriteLine("You aim the gun carefully at the target painted box and pull the trigger. A loud bang comes \n" +
                    "from the gun as it fires towards the box, shattering it into a thousand pieces. Where the box \n" +
                    "once stood, there is now a somewhat rusty key lying there. You pick it up, however you have \n" +
                    "no idea what it is used for.");
                Console.WriteLine("\n Mysterious key added to inventory");
                Console.WriteLine("\nPress any key to continue");
                Inventory.UnlockItem(4);
                Console.ReadKey();
                Console.Clear();
            }
            else if (Inventory.IsPickedUp(4))
                Console.WriteLine("You have already used the gun");

            else
                Console.WriteLine("You do not have a gun");
        }
        protected override void LookAround()
        {
            Console.WriteLine("The walls and ceiling are made out of old planks, with splinters and cracks all over. The floor \n" +
                "is made out of concrete, with a thin layer of dampness all over. In the room there are many \n" +
                "large crates, that appear to have been packed in a hurry, both being unorganized and hastily \n" +
                "thrown in.");
            if (!DocumentManager.IsPickedUp(5))
                Console.WriteLine("On top of one of the crates, you notice a piece of paper lying there.");

            if (!EventTriggers.SecretPassageIsClosed)
                Console.WriteLine("Behind the crates, the wall has disappeared, revealing a long corridor. The walls of the \n" +
                    "corridor are made out of polished and pristine white metal, bathed in light from modern \n" +
                    "lamps covering the ceiling. What is something so expensive and clean doing below such an \n" +
                    "old and broken house?");
            
        }
    }
}
