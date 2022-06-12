using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal class Mainhall : Room
    {
        bool foundEllenChandelier = false;
        public Mainhall() : base("Main hall", 1)
        { }

        public override int InsideRoom()
        {
            if (!Map.DiscoveredMainHall)
                FirstEntry();
            while(true)
            { 
                string userInput = Console.ReadLine();
                userInput = userInput.ToLower();
                Console.Clear();
                switch (userInput)
                {
                    // going to bedroom
                    case "go to bedroom":
                    case "go to left room":
                    case "go to left":
                    case "go to left door":
                        return 2;


                    // going to kitchen
                    case "go to kitchen":
                    case "go to front door":
                    case "go to front room":
                    case "go to center room":
                    case "go forward":
                    case "go to center":
                    case "go to front":
                        return 3;

                    // going to toolshed
                    case "go to toolshed":
                    case "go to right door":
                    case "go to right room":
                    case "go to right":
                        return 4;


                    case "inspect pool of blood":
                    case "inspect blood":
                    case "inspect pool":
                        InspectBlood();
                        break;

                    case "use uvflashlight":
                    case "use uv flashlight":
                    case "use flashlight":
                    case "use uv":
                        UseUVFlashlight();
                        break;

                    case "look around":
                        LookAround();
                        break;

                    case "help":
                        Help.HelpMenu();
                        break;

                    case "inventory":
                        Inventory.ViewInventory();
                        break;

                    case "document":
                    case "documents":
                    case "view documents":
                        DocumentManager.ViewDocuments();
                        break;

                    default:
                        Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                        break;
                }
            }
        }

        void InspectBlood()
        {
            if (!DocumentManager.IsPickedUp(1))
            {
                Console.WriteLine("You walk towards the pool of blood in the middle of the room, trying to figure out where the \n" +
                    "blood is coming from. As you get closer, you see a document lying half buried in the pool of \n" +
                    "blood. You pick it up and try to read it, however the blood makes it almost impossible to \n" +
                    "read, only letting you read a few letters.");
                Console.WriteLine("\n" + DocumentManager.Content(1));
                Console.WriteLine("\nBlood stained document added to documents");
                Console.WriteLine("\nPress any button to continue");
                DocumentManager.UnlockDocument(1);
                Console.ReadKey();
                Console.Clear();
            }

            else
                Console.WriteLine("You have already picked up the document");
        }

        void UseUVFlashlight()
        {
            if (Inventory.IsPickedUp(1) && !DocumentManager.IsPickedUp(8))
            {
                Console.WriteLine("You bring up your UV flashlight, slightly terrified yet determined to figure out what, or who is \n" +
                    "hanging in the chandelier. As you turn on the flashlight, you start shining from the bottom to \n" +
                    "the top. At first only a pair of shoes are revealed, dangling above the floor with a narrow line \n" +
                    "of blood sipping from their toes to the floor. The shoes appear to be similar to the ones of the \n" +
                    "person in the walls, which makes you think that this person worked together with them. As \n" +
                    "you bring the UV light even higher, your suspicions are confirmed, with black military pants. \n" +
                    "The source of the blood is yet to be seen. Going even higher, the torso reveals a black vest \n" +
                    "with many pockets. Inside the pockets you notice a key as well as a document. You grab \n" +
                    "both and start reading the document, which appears to have been printed rather than written \n" +
                    "by hand.");
                Console.WriteLine("\n" + DocumentManager.Content(8));
                Console.WriteLine("\nPress any button to continue");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("After reading the note, you slowly take the UV flashlight even higher up, to reveal the face. \n" +
                    "The visor on the helmet has been shattered, revealing one of the side arms of the chandelier \n" +
                    "sticking out from the mouth, like a serpent with blood slowly seeping from out of their mouth. \n" +
                    "Looking even further up, you see two blue eyes, with the eyeballs turned red, due to blood \n" +
                    "filling the eyes. Weird, it feels like you have seen those eyes before, although it is impossible \n" +
                    "to tell due to the blood giving them a brand new color At the top, you notice the hair. It is \n" +
                    "cluttered with blood, however you instantly notice the golden luxurious hair that used to be. \n" +
                    "Is it… Ellen? Looking closer, you instantly realise that it is the same blue eyes. It is Ellen, \n" +
                    "hanging lifeless in the chandelier, slowly swinging back and forth. Ellen I am so sorry, I did \n" +
                    "not make it in time.");
                Console.WriteLine("\nEscape route added to documents");
                Console.WriteLine("\nAttic key added to inventory");
                Console.WriteLine("\nPress any key to continue");

                DocumentManager.UnlockDocument(8);
                Inventory.UnlockItem(2);
                Console.ReadKey();
                Console.Clear();
            }
            else if (Inventory.IsPickedUp(1))
            {
                Console.WriteLine("you have already used the UV flashlight");
            }
            else
            {
                Console.WriteLine("you do not have a UV flashlight");
            }
        }

        protected override void FirstEntry()
        {
            bool lightsOff = true;
           
            Console.WriteLine("You slowly push aside the dark creaking front door, and see a room hazily covered in \n" +
                            "darkness. The room is filled with a musty smell, and your mouth is filled with the taste of wet \n" +
                            "paper. The taste and smell is almost enough to make you vomit. As you enter you hear the \n" +
                            "door vionently shutting behind you, covering you in a thick and black darkness. Feeling the \n" +
                            "door handle, it appears to have locked.");
            Console.WriteLine("\nType “look around“ to inspect your enviroment");
            
            while (lightsOff)
            {
                string input = Console.ReadLine();
                input = input.ToLower();
                Console.Clear();
                switch (input)
                {
                    case "look around":
                        Console.WriteLine("The room is pitch black, filled with a musty smell, and your mouth is filled with the taste of wet \n" +
                            "paper. The taste and smell is almost enough to make you vomit. You can hear the sound of \n" +
                            "creaking metallic slowly but methodically swinging back and forth above you, however it is \n" +
                            "impossible to see what it is through the thick darkness. You can also hear the sound of \n" +
                            "something liquid slowly dripping onto the floor. Feeling around the rotten and damp walls, \n" +
                            "you notice what feels like a lightswitch next to you.");
                        Console.WriteLine("\nType “help“ to get a list of actions and try to figure out what to do next");
                        break;

                    case "use lightswitch":
                        Console.WriteLine("The light blinds you with it’s surprising amount of power. You can now see the entire main hall \n" +
                            "bathing in light. Just like on the outside, the walls, floor and roof is made out of old \n" +
                            "planks with mold partially covering the walls. The planks look like place has not been renovated \n" +
                            "for over a century, and as if it could implode and bury you any second. There is a chandelier \n" +
                            "made out of pristine gold swinging back and forth, as if something was hanging in it. Right \n" +
                            "below the chandelier there’s a pool of blood, with blood slowly dripping down adding to the \n" +
                            "red pool on the floor, yet you cannot see the source of the blood. When looking around you \n" +
                            "see 3 other doors, one to the left, one in front of you as well as one to the right.");
                        Console.WriteLine("\nYou suddenly hear a voice from downstairs. It sounds just like… Ellen! You have to find a \n" +
                            "way down to the basement.");

                        lightsOff = false;
                        break;
                    case "help":
                        Help.HelpMenu();
                        Console.WriteLine("TIP: You have to turn on the lights");
                        break;
                    case "inventory":
                        Inventory.ViewInventory();
                        break;
                    case "document":
                    case "documents":
                        //Documents(pickup, document, documenttext);
                        break;
                    default:
                        Console.WriteLine("Invalid action, type “help“ for a list of actions");
                        break;
                }
            }
            Map.DiscoveredMainHall = true;
            Console.WriteLine("\nMain hall added to map");
            Console.WriteLine("\nPress any key to continue");
        }

        protected override void LookAround()
        {
            Console.Write("The light blinds you with it's surprising amount of power. You can now see the entire main \n" +
                        "hall bathing in light. Just like on the outside, the walls, floor and ceiling is made out of old \n" +
                        "planks with mold partially covering the walls. It looks like the place has not been renovated \n" +
                        "for over a century, and as if it could implode and bury you any second.");

            if (!foundEllenChandelier)
                Console.Write("There is a chandelier \n" +
                    "made out of pristine gold swinging back and forth, as if something was hanging in it. Right \n" +
                "below the chandelier there is a pool of blood, with blood slowly dripping down adding to the \n" +
                "red pool on the floor, yet you cannot see the source of the blood.");
            
            else
                Console.Write("In the ceiling, you see \n" +
                    "your wife hanging from the chandelier, slowly swinging back and forth with one of the side \n" +
                    "arms sticking out of her mouth like a serpent. Ellen, I am so sorry I could not make it in time. \n" +
                    "Blood is slowly dripping from her open mouth onto the floorboards below her, painting them red.");
            

            Console.Write("\nWhen looking around you see 3 other doors, ");
            if (Map.DiscoveredBedroom)
                Console.Write("The bedroom, ");

            else
                Console.Write("one to the left, ");

            if (Map.DiscoveredKitchen)
                Console.Write("The kitchen, ");

            else
                Console.Write("one in front, ");
            
            if (Map.DiscoveredToolshed)
                Console.Write("As well as the toolshed.");
            
            else
                Console.Write("As well as one to the right.");
            
            Console.WriteLine();
        }
    }
}
