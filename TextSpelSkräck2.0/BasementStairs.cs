using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal class BasementStairs : Room
    {
        public BasementStairs() : base("Basement stairs", 5)
        { }

        public override int InsideRoom()
        {
            if (!Map.DiscoveredBasementStairs)
                FirstEntry();
            return 0;
        }

        protected override void FirstEntry()
        {
            bool lightsOff = true;
            Console.WriteLine("You slowly walk down the stairs, the wood creaking and getting pushed down as you step on \n" +
                "them. The further down you get into the basement, the closer you get to the rasping \n" +
                "breathing, and the smell of coal grows stronger and stronger. Once you have reached the end \n" +
                "of the stairs, the breathing is right next to you, and the coal has gone from strong to \n" +
                "anesthetizing, numbing your smell and taste. As you feel around the damp walls, you feel \n" +
                "a rough plastic, similar to the lightswitch in the main hall but much older.");
            while (lightsOff)
            {
                string userInput = Console.ReadLine();
                userInput = userInput.ToLower();
                Console.Clear();
                switch (userInput)
                {
                    case "use lightswitch":
                        Console.WriteLine("As you press the lightswitch, a flickering light quickly illuminates the room. The transmission \n" +
                            "from pitch black darkness to a bright and stunning light burns your eyes, forcing you to cover \n" +
                            "them with your hand. As you’ve gotten used to the light in the basement, the breathing has \n" +
                            "disappeared, with only the aftertaste of coal in your mouth confirming that you did not just \n" +
                            "imagine that someone was there.");
                        lightsOff = false;
                        break;
                    case "look around":
                        Console.WriteLine("As you feel around the damp walls, you feel a rough plastic, similar to the lightswitch in the main hall but much older.");
                        break;
                    case "go to bedroom":
                        Console.WriteLine("The door behind you has closed, probably because of the wind. You do not want to go upstairs in the dark, because the stairs seem fragile");
                        break;
                    
                    default:
                        InsideRoomBaseSwitch(userInput);
                        break;
                }
            }
            Console.WriteLine("\nBasement stairs added to map");
            Console.WriteLine("\nPress any key to continue");
            Map.DiscoveredBasementStairs = true;
            Console.ReadKey();
            Console.Clear();
        }

        protected override int GoToCommand(string room)
        {
            switch (room)
            {
                case "cell":
                case "corridor":
                    return 6;

                case "bedroom":
                    if (EventTriggers.BasementDoorIsLocked)
                    {
                        Console.WriteLine("The door appears to be locked");
                        return id;
                    }
                    return 2;

                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    return id;
            }
        }

        protected override void InspectCommand(string inspectedObject)
        {
            switch(inspectedObject)
            {
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
            Console.Write("There is one small light bulb, shining a strong light over the damp and molded planks \n" +
                            "covering the ceiling and walls. These however appear to be in even worse shape than the rest \n" +
                            "of the house, as some have already collapsed, lying in pieces over the cold and hard stone \n" +
                            "floor. Right in front of you there is a long corridor with ");
            if (Map.DiscoveredCell)
            {
                Console.Write("A cell right at the end.");
            }
            else
            {
                Console.Write("what appears to be a door with bars \n" +
                "right at the end.");
            }
            if (EventTriggers.EllenIsAtStairs)
            {
                Console.Write("\nEllen is lying on the stone floor, seemingly unconscious.");
            }
            Console.WriteLine();
        }
    }
}
