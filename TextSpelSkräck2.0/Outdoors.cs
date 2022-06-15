using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal class Outdoors : Room
    {
        public Outdoors() : base("Outdoors", 0)
        { }

        public override int InsideRoom()
        {
            if (!Inventory.IsConsumed(4))
            {
                FirstEntry();
                return 1;
            }
            Console.WriteLine(name);
            while(true)
            {
                string userInput = Console.ReadLine();
                userInput = userInput.ToLower();
                string[] userInputArr = userInput.Split(' ');
                Console.Clear();

                if (userInputArr[0] == "go")
                {
                    int newRoom = GoToCommand(GoToAndPickUpFormatting(userInputArr));
                    if (newRoom != id)
                        return newRoom;
                }

                else if (userInputArr[0] == "inspect")
                    InspectCommand(InspectAndUseFormatting(userInputArr));

                else if (userInputArr[0] == "pick")
                    PickUpCommand(GoToAndPickUpFormatting(userInputArr));

                else if (userInputArr[0] == "use")
                    UseCommand(InspectAndUseFormatting(userInputArr));

                else
                    InsideRoomBaseSwitch(userInput);
            }
        }


        protected override void FirstEntry()
        {
            Console.WriteLine("The car door groans as you slowly open it, letting the cold air caress your face. You put your \n" +
            "left foot onto the damp dirt, feeling it trying to swallow your shoe. As you stand up, you finally \n" +
            "see the Campell estate resting before you. The foreign estate is made out of dark molded \n" +
            "planks, with many being bent or broken in different places. What appears to be windows \n" +
            "have been bordered up, making it impossible to see what the estate is hiding. A couple \n" +
            "meters in front of you there is a wooden door swinging freely in the wind, inviting you to \n" +
            "come in.");
            Console.WriteLine("\nType \"go to entrance\" to enter the house");
            bool loop = true;
            string input;
            while (loop)
            {
                input = Console.ReadLine();
                input = input.ToLower();
                switch (input)
                {
                    case "go to front door":
                    case "go to door":
                    case "go inside":
                    case "go to house":
                    case "go to entrance":
                    case "go to estate":
                        loop = false;
                        break;

                    case "look around":
                        Console.WriteLine("The estate appears to have been around for a long time, with dark planks covering the walls \n" +
                            "as well as the windows. As the wind passes by, the estate appears to shiver, slowly dancing \n" +
                            "back and forth all alone in the forest. It looks like the house has only 1 story, with perhaps a \n" +
                            "basement as well as an attic. In the front, there is a small porch with the door swinging freely \n" +
                            "in the wind. As you walk onto the porch, you notice a pool of blood to the side, with blood \n" +
                            "seeping through the planks going under the porch. Something is definitely wrong here, \n" +
                            "however you cannot go back without Ellen.");
                        break;

                    default:
                        Console.WriteLine("Invalid input, try typing 'go to entrance' to enter the estate");
                        break;

                }
            }
        }

        protected override int GoToCommand(string room)
        {
            switch (room)
            {
                case "entrance":
                case "main hall":
                case "mainhall":
                case "house":
                case "inside":
                case "estate":
                    return 1;

                case "car":
                    return -1;

                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    return id;
            }
        }

        protected override void InspectCommand(string inspectedObject)
        {
            switch (inspectedObject)
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
                case "flashlight":
                case "uv":
                case "uvflashlight":
                case "uv flashlight":
                    UseUVFlashlight();
                    break;

                default:
                    Console.WriteLine("Invalid input, try typing 'go to entrance' to enter the estate");
                    break;

            }

            }

            void UseUVFlashlight()
        {
            if (!DocumentManager.IsPickedUp(12))
            {
                Console.WriteLine("You shine the purple rays onto the bloodpool laying on the porch, revealing a lone arm \n" +
                    "violently torn off, with chunks of flesh sticking out as well as a broken bone where the \n" +
                    "shoulder should be. The arm has a white sleeve covering most of the skin, which probably is \n" +
                    "for the best. Looking at the hand, it has a note in their open palm, almost as if it was offering \n" +
                    "you the piece of paper. You pick up the note that surprisingly is free from bloodstains, yet it \n" +
                    "appears to only have a bunch of random symbols on it. ");
                Console.WriteLine("\n" + DocumentManager.Content(12));
                Console.WriteLine("\nUnknown document added to inventory");
                Console.WriteLine("\nPress any key to continue");
                DocumentManager.UnlockDocument(12);
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("You have already used the UV flashlight");
            }
        }

        // NOTE: this is only used in the lategame
        protected override void LookAround()
        {
            Console.Write("Standing on the porch, you look out to the overgrown grass, dancing calmly in the wind. Out \n" +
                "on the dirt road your car is patiently waiti for young, ready to leave at a moment's notice. Its \n" +
                "shining red coat of paint, with slight mud stains covering its lower parts feels out of this \n" +
                "world, having gotten used to the molded walls and the musty smell inside the estate.");
            if (DocumentManager.IsPickedUp(12))
            {
                Console.WriteLine("On the \n" +
                    "porch with you is the torn off arm, severely malformed and bathing in its own blood.");
            }
            else
            {
                Console.WriteLine("On the \n" +
                    "porch with you is a crimson pool of blood, having yet to coagulate just like the ones found \n" +
                    "inside.");
            }
        }
    }
}
