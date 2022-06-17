using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal class Toolshed : Room
    {
        bool unlockedHatch = false;
        public Toolshed() : base("Toolshed", 4)
        { }

        public override int InsideRoom()
        {
            if (!Map.DiscoveredToolshed)
                FirstEntry();
            if (Map.DiscoveredWalls)
                unlockedHatch = true;
            return base.InsideRoom();
        }

        protected override void FirstEntry()
        {
            Console.WriteLine("You enter a smaller room with the main hall shining through the open door");
            Console.WriteLine("Toolshed added to map");
            Console.WriteLine("\nPress any key to continue");
            Map.DiscoveredToolshed = true;
            Console.ReadKey();
            Console.Clear();
        }

        protected override int GoToCommand(string room)
        {
            switch(room)
            {
                case "main hall":
                    return 1;

                case "hatch":
                case "walls":
                case "downstairs":
                    if (unlockedHatch)
                        return 8;
                    else
                        Console.WriteLine("You try to open the hatch, however it appears to be locked");
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
                case "pool of blood":
                case "pool":
                case "blood":
                    GrabKey();
                    break;


                case "body":
                case "corpse":
                    if (DocumentManager.IsPickedUp(7))
                        GrabKey();

                    else
                        Console.WriteLine("there is no body around here");
                    break;

                case "tools":
                case "gardening tools":
                case "tools on wall":
                case "gardening equiment":
                case "equipment":
                case "wall":
                    InspectGardeningTools();
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
                case "key":
                case "basement key":
                case "stained key":
                case "note":
                case "document":
                    GrabKey();
                    break;
                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    break;
            }
        }

        protected override void UseCommand(string item)
        {
            switch(item)
            {
                case "flashlight":
                case "uv flashlight":
                case "uvflashlight":
                case "uv":
                    UseUVFlashlight();
                    break;

                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    break;
            }
        }
        void GrabKey()
        {
            if (!Inventory.IsPickedUp(0))
            {
                Console.WriteLine("The floorboards creak when you walk over to grab the key. When picking it up, a note next to \n" +
                                "the key catches your eye. Partly covered in blood, you try your best to decipher it.\n" +
                            "“How did--------\n" +
                            "locked in the basem---- - bedroom\n" +
                            "must be s-------- -\n" +
                            "-------fl---------- -\n" +
                            "---------------------”\n" +
                            "You also see a flashlight in the corner, however the bulb appears to be broken. Won’t be of \n" +
                            "any use.");
                Console.WriteLine("\n\nBasement key added to inventory");
                Console.WriteLine("\nBlood stained note added to documents");
                Console.WriteLine("\nPress any key to continue");
                Inventory.UnlockItem(0);
                DocumentManager.UnlockDocument(2);
                Console.ReadKey();
                Console.Clear();
            }

            else if (DocumentManager.IsPickedUp(7))
            {
                Console.WriteLine("Leaning towards the wall, its blood seeping through the visor, creating a pool of blood on the \n" +
                "floor, with the molded planks happily seeping up the red liquid. You are amazed at how much \n" +
                "blood one person actually contains.");
                
            }
            else
            {
                Console.WriteLine("The wretched stench of blood fills your nostrils as you examine the empty pool of blood, \n" +
                    "laying next to the wall. Is it just your imagination, or is the pool of blood slowly expanding?");
            }
        }

        void InspectGardeningTools()
        {
            Console.WriteLine("The tools covering the wall appear to be made out of some kind of metal, with some of them \n" +
                        "having plastic or rubber grips. The tools appear to have either been bought or polished \n" +
                        "recently, as they are clean enough for you to see your own reflection. You wonder who would \n" +
                        "prioritize cleaning their gardening tools over taking care of their home.");
        }

        void UseUVFlashlight()
        {
            if (Inventory.IsPickedUp(1) && !DocumentManager.IsPickedUp(7))
            {
                Console.WriteLine("As you shine the flashlight onto the bloodpool, another corpse reveals itself. The corpse is \n" +
                    "sitting down, leaning towards the wall with the arms hanging lifeless from each side. \n" +
                    "This one has the same black outfit as the one inside the walls, as well as the black visor. \n" +
                    "There is blood seeping out from inside the mask, going down the chest and into a pool on \n" +
                    "the floor. As you check the pockets, you find two documents that appear to have been \n" +
                    "untouched from the blood. One appears to be printed, rather than written by hand.");
                Console.WriteLine("\n" + DocumentManager.Content(9));
                Console.WriteLine("\nPress any button to continue");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("The other document appears to have been written by hand rather than printed. \n" +
                    "It appears to contain notes about some kind of experiment");
                Console.WriteLine("\n" + DocumentManager.Content(7));
                Console.WriteLine("\nList of members operation gestalt added to documents");
                Console.WriteLine("\n\nNumber habits with G001 added to documents");
                Console.WriteLine("\nPress any key to continue");
                DocumentManager.UnlockDocument(7);
                DocumentManager.UnlockDocument(9);
                Console.ReadKey();
                Console.Clear();
            }
            else if (DocumentManager.IsPickedUp(7))
            {
                Console.WriteLine("You have already used the UV flashlight");
            }
            else
            {
                Console.WriteLine("You do not have a UV flashlight");
            }
        }

        protected override void LookAround()
        {
            Console.WriteLine("The light from the main hall is shining through the door gap, giving the small room a faint \n" +
                    "light and making it barely visible. Different kinds of gardening equipment covering the walls, \n" +
                    "put in place by a tool board as old as the house. The tools however appear to be new, \n" +
                    "compared to the rest of the house. At the end of the room there is a hatch, and next to \n" +
                    "the hatch you see another pool of blood");
            if (DocumentManager.IsPickedUp(7))
            {
                Console.WriteLine(" coming from one of the soldiers found with the UV \n" +
                    "flashlight.");
            }
            if (!Inventory.IsPickedUp(0))
            {
                Console.WriteLine(" as well as a stained key.");
            }
            else if (DocumentManager.IsPickedUp(7) == false)
            {
                Console.WriteLine(".");
            }
        }
    }
}
