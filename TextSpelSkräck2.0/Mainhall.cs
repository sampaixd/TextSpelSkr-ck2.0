using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal class Mainhall : Room
    {
        bool activatedLightSwitch = false;
        bool foundEllenChandelier = false;
        public Mainhall() : base("Main hall", 1)
        { }

        public override int InsideRoom()
        {
            if (!Map.DiscoveredMainHall)
                FirstEntry();

            string userInput = Console.ReadLine();
            userInput = userInput.ToLower();
            switch(userInput)
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

                case "look around":
                    LookAround();
                    break;

                case "help":
                    Help.HelpMenu();
                    break;

                case "inventory":
                    Inventory.DisplayInventory();
                    break;
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
                        Inventory.DisplayInventory();
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
