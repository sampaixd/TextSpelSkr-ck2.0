using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal class Cell : Room
    {
        bool codeLockPuzzleIsSolved;
        bool posterIsRemoved;
        bool isFirstTimeAttemptingPuzzle;
        public Cell() : base ("Cell", 6)
        {
            codeLockPuzzleIsSolved = false;
            posterIsRemoved = false;
            isFirstTimeAttemptingPuzzle = true;
        }

        public override int InsideRoom()
        {
            if (!Map.DiscoveredCell)
                FirstEntry();

            return base.InsideRoom();
        }

        protected override void FirstEntry()
        {
            Console.WriteLine("You start walking towards the door with bars at the end of the corridor. The sound of you \n" +
                "walking over the cold stone floor echoes through the basement, with the wooden walls \n" +
                "getting closer and closer as you reach further, forcing you to walk in a straight line. While \n" +
                "you are walking through the corridor, you cannot shake off the feeling of being watched, yet you \n" +
                "cannot see or hear anything, however the faint smell of coal fills the air you are breathing. At \n" +
                "last, you reach the end of the corridor. The walls widen again, giving you some much \n" +
                "appreciated space. Looking through the bars, you see someone lying on a \n" +
                "dirty mattress on the floor. Is that… Ellen! You shake the bars trying to open the door to no \n" +
                "avail, as the bars are way too thick for you to be able to force your way through. Looking \n" +
                "again, you see a code lock keeping the door locked.");
            Console.WriteLine("\nCell added to map");
            Console.WriteLine("\nPress any key to continue");
            Map.DiscoveredCell = true;
            Console.ReadKey();
            Console.Clear();
        }

        protected override int GoToCommand(string room)
        {
            switch(room)
            {
                case "basement stairs":
                case "stairs":
                    return 5;

                case "storage":
                case "left":
                case "left corridor":
                    if (EventTriggers.IsCarryingEllen)
                    {
                        Console.WriteLine("You do not have time for that");
                        return id;
                    }
                    return 7;

                case "wall":
                case "hole":
                case "poster":
                case "secret hole":
                case "hidden hole":
                    if (codeLockPuzzleIsSolved)
                        return 8;
                    else
                    {
                        Console.WriteLine("There is currently no way to get inside the walls");
                        return id;
                    }
                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    return id;
            }
        }

        protected override void InspectCommand(string inspectedObject)
        {
            switch(inspectedObject)
            {
                case "codelock":
                case "puzzle":
                case "lock":
                case "code lock":
                    CodeLockPuzzleRequirements();
                    break;

                case "poster":
                    InspectPoster();
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
                case "document":
                case "note":
                case "paper":
                    PickupNote();
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
                case "codelock":
                case "puzzle":
                case "lock":
                case "code lock":
                    CodeLockPuzzleRequirements();
                    break;

                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    break;
            }
        }

        void InspectPoster()
        {
            if (EventTriggers.IsCarryingEllen)
            {
                Console.WriteLine("You do not have time for that");
            }
            else if (DocumentManager.IsPickedUp(5) && !posterIsRemoved && codeLockPuzzleIsSolved)
            {
                Console.WriteLine("You take a last good look at the ragged poster before you begin tearing it off the wall. It turns \n" +
                        "out to be very fragile, as you almost accidentally rip it in half. Behind the poster, a large \n" +
                        "gaping hole is revealed, seemingly leading into the wall.");
                Console.WriteLine("\nPress any key to continue");
                posterIsRemoved = true;
                Console.ReadKey();
                Console.Clear();
                if (EventTriggers.EllenIsAtStairs)
                {
                    Console.WriteLine("As you tear off the poster inside the cell, you suddenly hear a scream coming from the \n" +
                        "basement stairs, followed by the sound of a door violently shutting. That scream sounded \n" +
                        "just like Ellen.");
                    Console.WriteLine("\nPress any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else if (posterIsRemoved)
            {
                Console.WriteLine("You have already removed the poster");
            }
            else
            {
                Console.WriteLine("The poster is large, at least 1 meter in length and half a meter in width. On the poster there \n" +
                    "are bright colors in the background, turned more dull by time. The alphabet is lined up in 3 \n" +
                    "different lines in the center of the cell, however it is not easy to read all of the letters due to \n" +
                    "the many scars on the poster. What kind of person puts up a poster of the alphabet inside a \n" +
                    "cell?");
            }
        }

        void PickupNote()
        {
            if (!DocumentManager.IsPickedUp(4))
            {
                Console.WriteLine("You pick up the note lying on the floor. There is something written on it, and the handwriting \n" +
                    "looks like something from a child");
                Console.WriteLine("\n" + DocumentManager.Content(4));
                Console.WriteLine("\n\nMysterious note added to documents");
                Console.WriteLine("\nPress any key to continue");
                DocumentManager.UnlockDocument(4);
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("You have already picked up the note");
            }
        }

        void CodeLockPuzzleRequirements()
        {
            if (!codeLockPuzzleIsSolved)
            {
                CodeLock();

                // De Morgan's law sexyness
                if (!(codeLockPuzzleIsSolved || DocumentManager.IsPickedUp(4)))
                {
                    Console.WriteLine("You frantically try rolling the different numbers, hoping to get it right, however that appears to \n" +
                        "be an impossible task. You get filled with the feeling of hopelessness, as you got so close \n" +
                        "yet you are still unable to get her. As you give up on getting the right combination, a piece of \n" +
                        "paper catches your eye right below the codelock, lying on the floor. You pick up the note and \n" +
                        "notice that there is something written on it. The handwriting looks like something from a child.");
                    Console.WriteLine("\n" + DocumentManager.Content(4));
                    Console.WriteLine("\n\nMysterious note added to documents");
                    Console.WriteLine("\nPress any key to continue");
                    DocumentManager.UnlockDocument(4);
                    Console.ReadKey();
                    Console.Clear();
                }
                if (codeLockPuzzleIsSolved)
                {
                    Console.WriteLine("As you roll the last number onto the right position, a metallic click comes from the lock as the \n" +
                        "shackle releases it’s tight grip off the locking mechanism. You remove the lock, throwing it \n" +
                        "aside and entering the cell. The walls, ceiling and floor inside are made out of old concrete, \n" +
                        "with cracks covering the concrete. The only decoration inside the cell is an old poster barely \n" +
                        "hanging onto the wall. In the corner of the room, an old mattress is laying on the floor, with \n" +
                        "Ellen lying on it. Her hair has gone from her former golden color to a muddy brown, and her \n" +
                        "arms and elbows show scratches and bruises, indicating that she has been here for a long \n" +
                        "time. Ellen is wearing what appears to have once been a white tank top, and a dirty pair of \n" +
                        "jeans. You walk towards her, shaking her with the hope that she will wake up. Eventually you \n" +
                        "see life in her, as she groans and rolls over from side to side. Feeling her forehead, it burns \n" +
                        "with an intense heat, forcing you to quickly remove your hand. She needs a doctor \n" +
                        "immediately! You lift her up in your arms, carrying her out of the cell. You need to get her to \n" +
                        "the car, now!");
                    Console.WriteLine("\n\nPress any key to continue");
                    EventTriggers.IsCarryingEllen = true;
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        void CodeLock()
        {
            int[] insertedNumbers = { 0, 0, 0, 0 };
            int currentlySelectedNumber = 0;
            while (true)
            {
                DisplayCodeLock(insertedNumbers, currentlySelectedNumber);
                int[] temp = NavigateCodeLock(insertedNumbers[currentlySelectedNumber], currentlySelectedNumber);
                if (temp[1] == -1)
                    return;

                insertedNumbers[currentlySelectedNumber] = temp[0];
                currentlySelectedNumber = temp[1];

                if (insertedNumbers[0] == 9 && insertedNumbers[1] == 2 && insertedNumbers[2] == 5 && insertedNumbers[3] == 1)
                {
                    codeLockPuzzleIsSolved = true;
                    return;
                }
            }
        }

        void DisplayCodeLock(int[] insertedNumbers, int currentlySelectedNumber)
        {
            Console.WriteLine("----------");
            Console.Write("   ");
            for (int i = 0; i < 4; i++)
                DisplayNumber(insertedNumbers[i], i == currentlySelectedNumber);

            Console.WriteLine();
            Console.WriteLine("----------");
            Console.WriteLine("\n\nPress w, a, s, d or arrow keys to navigate the codelock and esc to exit the puzzle");
        }

        void DisplayNumber(int insertedNumber, bool isSelected)
        {
            if (isSelected)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.Write(insertedNumber);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        int[] NavigateCodeLock(int insertedNumber, int selectedNumber)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            
            switch(keyPressed.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    insertedNumber = (insertedNumber >= 9) ? 0 : ++insertedNumber;
                    break;

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    insertedNumber = (insertedNumber <= 0) ? 9 : --insertedNumber;
                    break;

                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    selectedNumber = (selectedNumber >= 3) ? 0 : ++selectedNumber;
                    break;

                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    selectedNumber = (selectedNumber <= 0) ? 3 : --selectedNumber;
                    break;

                case ConsoleKey.Escape:
                    selectedNumber = -1;
                    break;
            }
            Console.Clear();
            return new int[] { insertedNumber, selectedNumber };

        }


        protected override void LookAround()
        {
            Console.Write("Right in front of you there is a door with thick and rusted iron bars. ");

            if (!codeLockPuzzleIsSolved)
                Console.Write("Inside the room lies Ellen, \n" +
                    "however in order to reach her you have to find the combination for the code lock. ");
            
            Console.Write("Behind you is the corridor \n" +
                "leading back to the basement stairs, and looking to your left, there appears to be another \n" +
                "corridor leading ");
            if (!Map.DiscoveredStorage)
                Console.Write("somewhere.");
            
            else
                Console.Write("to the storage.");
       

            if (!DocumentManager.IsPickedUp(4))
                Console.Write("On the ground below the code lock, there is a damp paper lying there.");
   

            if (codeLockPuzzleIsSolved)
                Console.WriteLine("The walls, ceiling and floor inside the cell are made out of old concrete, \n" +
                    "with cracks covering \n" +
                    "the concrete. In the corner of the room, an old mattress is laying on the floor where you found Ellen.");


            if (!posterIsRemoved && codeLockPuzzleIsSolved)
                Console.WriteLine("The only decoration inside the cell is an old poster barely hanging onto the wall.");
            
            else if (posterIsRemoved)
                Console.WriteLine("The poster is lying on the floor with a large scar almost cutting it in half, with a large hole \n" +
                    "leading into the wall taking its former place.");
            
        }
    }
}
