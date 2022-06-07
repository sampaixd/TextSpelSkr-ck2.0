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
        public Mainhall() : base("Main hall", 0)
        { }

        public override void InsideRoom()
        {
            string userInput = Console.ReadLine();
            userInput = userInput.ToLower();
            switch(userInput)
            {
                // going to bedroom
                case "go to bedroom":
                case "go to left room":
                case "go to left":
                case "go to left door":

                    break;


                // going to kitchen
                case "go to kitchen":
                case "go to front door":
                case "go to front room":
                case "go to center room":
                case "go forward":
                case "go to center":
                case "go to front":

                    break;

                // going to toolshed
                case "go to toolshed":
                case "go to right door":
                case "go to right room":
                case "go to right":

                    break;

                case "look around":
                    LookAround();
                    break;
            }
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
