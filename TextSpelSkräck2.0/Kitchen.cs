using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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
                string[] userInputArr = userInput.Split(' ');
                Console.Clear();

                if (userInputArr[0] == "go")
                {
                    int newRoom = GoToCommand(GoToAndPickUpFormatting(userInputArr));
                    if (newRoom != id)
                        return newRoom;
                }

                else if (userInputArr[0] == "use")
                    UseCommand(InspectAndUseFormatting(userInputArr));

                else if (userInputArr[0] == "inspect")
                    InspectCommand(InspectAndUseFormatting(userInputArr));

                else
                    InsideRoomBaseSwitch(userInput);


                /*string userInput = Console.ReadLine();
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

                    case "inspect table":
                    case "inspect round table":
                    case "inspect wooden table":
                        InspectTable();
                        break;

                    case "inspect counter":
                    case "inspect dishes":
                    case "inspect dirty dishes":
                    case "inspect slab":
                        InspectCounter();
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
                }*/
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

        protected override int GoToCommand(string room)
        {
            throw new NotImplementedException();
        }

        protected override void InspectCommand(string inspectedObject)
        {
            throw new NotImplementedException();
        }

        protected override void PickUpCommand(string item)
        {
            throw new NotImplementedException();
        }

        protected override void UseCommand(string item)
        {
            throw new NotImplementedException();
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

        void InspectTable()
        {
            Console.WriteLine("The round wooden table has an old tablecloth covering the old wood hidden beneath. \n" +
                        "Different kinds of molded food cover the table, emitting a musty and rotten smell. \n" +
                        "The thought that this was once used for eating dinner is almost impossible to imagine.");
        }

        void InspectCounter()
        {
            Console.WriteLine("The dishes have been piled up all over the counter, reaching the same height as you. Flies \n" +
                        "are plentiful and seem to fight over the massive pile of rotten waste, as if there was not \n" +
                        "enough for all of them. Whoever used to live here, it seems like doing dishes was not on \n" +
                        "their priority list.");
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
            {
                ModernCodeLock();
                if (!AtticIsLocked)
                {
                    Console.WriteLine("The machine beeps as it prints out “correct” onto the display screen. To your right, the ceiling \n" +
                        "slowly opens, and after a few seconds a metallic ladder starts descending from above. This \n" +
                        "must lead to the attic.");
                    Console.WriteLine("\nPress any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

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
            bool interactingWithPuzzle = true;
            while (interactingWithPuzzle)
            {
                
                int[] insertedNumbers = InsertCodeLockNumbers();
                if (insertedNumbers[0] == -1)
                    return;

                if (GetCodeLockResults(insertedNumbers))
                    return;
            }
        }

        int[] InsertCodeLockNumbers()
        {
            int[] insertedNumbers = new int[3];
            for (int i = 0; i < 3; i++)
            {
                DisplayCodeLock(i, insertedNumbers);
                insertedNumbers[i] = GetCodeLockInput();

                if (insertedNumbers[i] == -1)
                {
                    insertedNumbers[0] = -1;
                    return insertedNumbers;
                }

                Console.Clear();
            }
            DisplayCodeLock(3, insertedNumbers);
            Thread.Sleep(1000);
            Console.Clear();
            return insertedNumbers;
        }

        void DisplayCodeLock(int currentLoop, int[] insertedNumbers)
        {
            Console.WriteLine("-----------------------");
            Console.Write("|       ");
            for (int i = 0; i < 3; i++)
            {
                if (currentLoop > i)
                    Console.Write($"{insertedNumbers[i]} ");
                else
                    Console.Write("- ");
            }
            Console.WriteLine("        |");
            Console.WriteLine("-----------------------");
            //Console.WriteLine("|       -  -  -       |");
        }
        int GetCodeLockInput()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                switch (consoleKey.Key)
                {

                    case ConsoleKey.D0:
                        Console.ForegroundColor = ConsoleColor.White;
                        return 0;

                    case ConsoleKey.D1:
                        Console.ForegroundColor = ConsoleColor.White;
                        return 1;

                    case ConsoleKey.D2:
                        Console.ForegroundColor = ConsoleColor.White;
                        return 2;

                    case ConsoleKey.D3:
                        Console.ForegroundColor = ConsoleColor.White;
                        return 3;

                    case ConsoleKey.D4:
                        Console.ForegroundColor = ConsoleColor.White;
                        return 4;

                    case ConsoleKey.D5:
                        Console.ForegroundColor = ConsoleColor.White;
                        return 5;

                    case ConsoleKey.D6:
                        Console.ForegroundColor = ConsoleColor.White;
                        return 6;

                    case ConsoleKey.D7:
                        Console.ForegroundColor = ConsoleColor.White;
                        return 7;

                    case ConsoleKey.D8:
                        Console.ForegroundColor = ConsoleColor.White;
                        return 8;

                    case ConsoleKey.D9:
                        Console.ForegroundColor = ConsoleColor.White;
                        return 9;

                    case ConsoleKey.Escape:
                        Console.ForegroundColor = ConsoleColor.White;
                        return -1;
                        

                }
            }
        }

        bool GetCodeLockResults(int[] insertedNumbers)
        {
            if (CodeLockCombinationIsCorrect(insertedNumbers))
            {
                DisplayCorrectAnswer();
                Thread.Sleep(2000);
                AtticIsLocked = false;
                Console.Clear();
                 return true;
            }
            else
            {
                DisplayIncorrectAnswer();
                Thread.Sleep(2000);
                Console.Clear();
                return false;
            }
        }

        bool CodeLockCombinationIsCorrect(int[] insertedNumbers)
        {
            return insertedNumbers[0] == 1 && insertedNumbers[1] == 3 && insertedNumbers[2] == 5;
        }

        void DisplayCorrectAnswer()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("|    C O R R E C T    |");
            Console.WriteLine("-----------------------");
        }

        void DisplayIncorrectAnswer()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("|  I N C O R R E C T  |");
            Console.WriteLine("-----------------------");
        }


        protected override void LookAround()
        {
            throw new NotImplementedException();
        }
    }
}
