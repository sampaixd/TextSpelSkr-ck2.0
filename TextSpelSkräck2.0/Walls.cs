using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal class Walls : Room
    {
        public Walls() : base("Walls", 8)
        { }

        public override int InsideRoom()
        {
            if (!Map.DiscoveredWalls)
                FirstEntry();
            return base.InsideRoom();
        }
        protected override void FirstEntry()
        {
            Console.WriteLine("You walk through the gaping hole inside the cell, revealing a large open space from inside \n" +
                            "the wall.There are cobwebs and insects all over the place, however something special \n" +
                            "catches your eye. Someone is lying in the corner inside the wall, with their back pushed up \n" +
                            "against the wall and their hand on their stomach. You say “hello?” however you get no \n" +
                            "response. As you walk closer, you notice that there is blood slowly oozing out from between \n" +
                            "his fingers, running down onto their leg and onto the floor.Once you have reached the \n" +
                            "person, you notice that they have a military grade vest, as well as a helmet with a black visor \n" +
                            "covering their face.You grab their hand and try feeling if there is a pulse, however there \n" +
                            "appears to be none. This person is dead.Looking back, you notice there was a pocket \n" +
                            "behind his hand, revealing a document inside. You pick up the document and read it, \n" +
                            "however parts of the document are covered in blood and therefore unreadable.");
            Console.WriteLine("\n" + DocumentManager.Content(6));
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Once you finish reading the document, you notice that the person is holding something in the \n" +
                "other hand. It appears to be a flashlight, and as you turn it on it reveals a purple UV light. \n" +
                "This could probably be useful.");
            Console.WriteLine("Walls added to map");
            Console.WriteLine("\nUV flashlight added to inventory");
            Console.WriteLine("\nInformation regarding UV light added to documents");
            Console.WriteLine("\nPress any key to continue");
            Inventory.UnlockItem(1);
            DocumentManager.UnlockDocument(6);
            Console.ReadKey();
            Console.Clear();
        }

        protected override int GoToCommand(string room)
        {
            switch(room)
            {
                case "cell":
                    return 6;

                case "wall":
                case "corridor":
                case "toolshed":
                case "hatch":
                case "through wall":
                case "through narrow hallway":
                case "through gap":
                case "narrow pathway":
                case "pathway":
                    return 4;

                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    return id;
            }
        }

        protected override void InspectCommand(string inspectedObject)
        {
            switch(inspectedObject)
            {
                case "body":
                case "dead body":
                case "corpse":
                case "person":
                    Console.WriteLine("The corspe is sitting leaned against the inner wall, with their hands to their sides.");
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
            switch (item)
            {

                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    break;

            }
        }

        protected override void LookAround()
        {
            Console.WriteLine("The lighting is very sparse, making it hard to see inside the wall. The planks inside the wall \n" +
                            "appear to have deteriorated even more than the walls in the basement, with huge chunks of \n" +
                            "some of the planks missing, To your left is the body you found, lying lifeless in the corner.");
        }

 
    }
}
