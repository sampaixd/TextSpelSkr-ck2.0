using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal class Kitchen : Room
    {
        bool AtticIsLocked = true;
        bool isFirstTimeUsingCodelock = true;
        public Kitchen() : base("Kitchen", 3)
        { }

        public override int InsideRoom()
        {
            if (!Map.DiscoveredKitchen)
                FirstEntry();
            Console.WriteLine(name);
            while (true)
            {
                string userInput = Console.ReadLine();
                userInput = userInput.ToLower();
                Console.Clear();
                switch (userInput)
                {
                    case "go to main hall":
                    case "go to mainhall":
                    case "go to hall":
                        return 1;

                    case "go to attic":
                    case "go upstairs":
                    case "go to the attic":
                    case "go to ladder":
                    case "go to metallic ladder":
                        if (AtticIsLocked)
                            return 10;
                        else
                        {
                            Console.WriteLine("You look around for the attic, however it is nowhere to be found");
                            if (Inventory.IsConsumed(2))
                                Console.WriteLine("Maybe something will happen if I manage to enter the correct code");
                        }
                        break;

                    case "pick up note":
                    case "pick up document":
                    case "pick up recipe":
                    case "pick up book":
                    case "pick up cookbook":
                    case "inspect book":
                    case "inspect recipe book":
                        PickupRecipe();
                        break;

                    case "use key":
                    case "use attic key":
                    case "use attickey":
                    case "use item":
                        UseKey();
                        break;

                    case "use puzzle":
                    case "use codelock":
                    case "use modern codelock":
                    case "inspect codelock":
                    case "inspect puzzle":
                        ModernCodeLockRequirements();
                        break;


                    default:
                        InsideRoomBaseSwitch(userInput);
                        break;
                }
            }
        }

        protected override void FirstEntry()
        {
            Console.WriteLine("You enter the room in front of you, with the door squeaking loudly as you slowly push it open.");
            Console.WriteLine("Kitchen added to map");
            Console.WriteLine("\nPress any key to continue");
            Map.DiscoveredKitchen = true;
            Console.ReadKey();
            Console.Clear();
        }

        void PickupRecipe()
        {
            if (!DocumentManager.IsPickedUp(3))
            {
                Console.WriteLine("You walk towards the dirty counter, doing your best to avoid the dirty dishes as well as all the \n" +
                                "flies defending it. Once you have reached the book, you notice a loose piece of paper lying \n" +
                                "in the middle of it. You pick up the damp page from the book, which appears to be a sort of recipe.");
                Console.WriteLine("\n" + DocumentManager.Content(3));
                Console.WriteLine("\n\nRecipe for homemade bread added to documents");
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
            else
                Console.WriteLine("You have already picked up the recipe");
        }

        void UseKey()
        {
            if (Inventory.IsPickedUp(2) && !Inventory.IsConsumed(2))
            {
                Console.WriteLine("The key fits perfectly as you slide it into the keyhole. Turning the lock feels smooth and new, \n" +
                    "as if it had been polished recently. The keyhole clicks as you reach the end, and to the right \n" +
                    "of you part of the wall begins to move aside, revealing a shiny metallic keypad with a small \n" +
                    "screen right above it. The screen is shining a green light and says with black letters “Enter password”");
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
            else if (Inventory.IsPickedUp(0) && !Inventory.IsConsumed(0))
                Console.WriteLine("You try to use the key you found, however it does not seem to fit the lock");

            else if (AtticIsLocked)
                Console.WriteLine("You do not have the key needed for this");

            else
                Console.WriteLine("You have already used the key");

        }

        void ModernCodeLockRequirements()
        {
            if (Inventory.IsConsumed(2) && AtticIsLocked)
                ModernCodeLock();

            else if (!Inventory.IsConsumed(2))
                Console.WriteLine("You cannot see a puzzle nearby");

            else
                Console.WriteLine("You have already solved this puzzle");

            if (isFirstTimeUsingCodelock && AtticIsLocked)
            {
                Console.WriteLine("The code does not appear to work, maybe it has been changed since the note was written? I better check around for clues");
                Console.WriteLine("\nPress any key to continue");
                isFirstTimeUsingCodelock = false;
                Console.ReadKey();
                Console.Clear();
            }
        }
        void ModernCodeLock()
        {
            
        }

        protected override void LookAround()
        {
            throw new NotImplementedException();
        }
    }
}
