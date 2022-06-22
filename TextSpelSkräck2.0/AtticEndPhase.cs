using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal class AtticEndPhase
    {
        public int EndPhase()
        {
            Console.WriteLine("You walk up to the door, and try to push it open. It is heavy but you are slowly making \n" +
            "progress. Suddenly the smell of coal fills the air, and you hear a voice behind you. “Hello” it \n" +
            "is your wife, with her tank top and jeans still on. She is standing in a weird way, as if she did \n" +
            "not know how to stand up normally, hunched over and with her arms dangling below her. Her \n" +
            "head is tilted to the side, and a smile is forced onto her face, as if she was trying to give a \n" +
            "sense of false security. Suddenly, she starts getting closer and closer. You will not be able to \n" +
            "get the door open in time. What do you do?");

            int attempts = 0;
            while (attempts < 3)
                attempts = EndPhaseGetAction(attempts);

            if (attempts == 3)
                return EndPhaseTimeOut();

            else if (attempts == 4)
                return EndPhaseAttemptEscape();

            else if (attempts == 5)
                return EndPhaseUseGun();

            else if (attempts == 6)
                return EndPhaseUseUVFlashlight();

            throw new ArgumentException();

        }

        int EndPhaseGetAction(int currentAttempt)
        {
            string userInput = Console.ReadLine();
            userInput = userInput.ToLower();
            string[] userInputArr = userInput.Split(' ');
            Console.Clear();
            switch (userInputArr[0])
            {
                case "go":
                    return EndPhaseGoToCommand(GoToAndPickUpFormatting(userInputArr), currentAttempt);

                case "inspect":
                    EndPhaseInspectCommand(InspectAndUseFormatting(userInputArr));
                    break;

                case "pick":
                    EndPhasePickUpCommand(GoToAndPickUpFormatting(userInputArr));
                    break;


                case "use":     // this is one of the options that can give you some kind of ending early
                    return EndPhaseUseCommand(InspectAndUseFormatting(userInputArr), currentAttempt);

                default:
                    InsideRoomBaseSwitch(userInput);
                    break;
            }
            Console.WriteLine("Ellen is slowly getting closer...");
            return ++currentAttempt;
        }

        string GoToAndPickUpFormatting(string[] insertedCommand)
        {
            if (insertedCommand.Length <= 1)    // if only "go" or "pick" was inserted
                return "";
            string formattedString = "";
            for (int i = 2; i < insertedCommand.Length; i++)
            {
                formattedString += insertedCommand[i] + " ";
            }
            return formattedString.Remove(formattedString.Length - 1);  // removes the last character
        }
        string InspectAndUseFormatting(string[] insertedCommand)
        {
            string formattedString = "";
            for (int i = 1; i < insertedCommand.Length; i++)
            {
                formattedString += insertedCommand[i] + " ";
            }
            return formattedString.Remove(formattedString.Length - 1);  // removes the last character
        }

        int EndPhaseGoToCommand(string input, int currentAttempt)
        {
            switch (input)
            {
                case "kitchen":
                case "downstairs":
                case "ladder":
                case "down ladder":
                    Console.WriteLine("You think about trying to escape down to the kitchen, however Ellen is blocking the way to the ladder");
                    break;

                case "door":
                case "exit":
                case "end of the room":
                case "metallic door":
                case "escape":
                    return 4;

                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    break;
            }
            Console.WriteLine("Ellen is slowly getting closer...");
            return ++currentAttempt;
        }

        void EndPhaseInspectCommand(string input)
        {
            switch (input)
            {
                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    break;
            }
        }

        void EndPhasePickUpCommand(string input)
        {
            switch (input)
            {
                case "gun":
                case "weapon":
                case "pistol":
                    Console.WriteLine("The gun is on the table, however Ellen is blocking me from getting to it");
                    break;

                case "document":
                case "note":
                case "paper":
                    Console.WriteLine("Now is not the time for that!");
                    break;

                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    break;
            }
        }

        int EndPhaseUseCommand(string input, int currentAttempt)
        {
            switch (input)
            {
                case "gun":
                case "weapon":
                case "pistol":
                    if (Inventory.IsPickedUp(3))
                        return 5;
                    Console.WriteLine("The gun is on the table, however Ellen is blocking me from getting to it");
                    break;

                case "uvflashlight":
                case "uv flashlight":
                case "flashlight":
                case "uv":
                    return 6;

                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    break;

            }
            Console.WriteLine("Ellen is slowly getting closer...");
            return ++currentAttempt;
        }

        void InsideRoomBaseSwitch(string userInput)
        {
            switch (userInput)

            {
                case "look around":
                    LookAround();
                    break;

                case "inventory":
                    Inventory.ViewInventory();
                    break;

                case "document":
                case "documents":
                case "view documents":
                    DocumentManager.ViewDocuments();
                    break;

                case "help":
                    Help.HelpMenu();
                    break;

                case "map":
                    Map.ViewMap();
                    break;

                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    break;
            }
        }

        void LookAround()
        {
            Console.WriteLine("With your back pressing against the cold metal door, you have most of the attic within your \n" +
                "sights. There is a table in the center of the room, with a computer terminal on it");
                if (!Inventory.IsPickedUp(3))
                    Console.Write(", as well as a gun");

            Console.WriteLine(". At the other side of the room, the hatch leading down to the kitchen is slightly visible, \n" +
                "blocked by that thing slowly moving towards you. Its almost robotic movements make you \n" +
                "want to vomit, not to mention the suffocating smell of coal oozing from it. It slowly moves \n" +
                "towards you, walking over the pristine planks covering the entire attic.");
        }

        int EndPhaseTimeOut()
        {
            Console.WriteLine("Frozen in place, you let Ellen walk up to you. Her grin looks even more disturbing up close \n" +
                            "than from a distance. She slowly brings her arms up, and strongly grips your throat. You try \n" +
                            "to fight back, hitting her in the face, kicking her, trying to tear off her arms from your throat, \n" +
                            "however it is all in vain. You feel your strength slowly seeping away as the room goes darker \n" +
                            "and darker until the only thing you see is your wife, smiling at you.");
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
            return -2;
        }

        int EndPhaseAttemptEscape()
        {
            Console.WriteLine("You quickly turn around, giving your all into pushing the metallic door open before she \n" +
                            "reaches you. You manage to move the door slowly but surely, and just as you see a glimpse \n" +
                            "of the trees outside, you feel something hard hit your head, and you fall over. Your vision \n" +
                            "begins to fade, you see Ellen standing besides you, smiling before everything goes dark.");
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
            return -2;
        }

        int EndPhaseUseGun()
        {
            Console.WriteLine("You aim the gun carefully towards Ellen, as she is slowly getting closer and closer. You \n" +
                                "hesitate for a second, and then shoot. The first bullet hits her in the right shoulder, and she \n" +
                                "stumbles backwards a bit. She then regains her balance and stats moving towards you \n" +
                                "again. You take another shot, this time in the stomach. She crouches over, but keeps \n" +
                                "walking. You shoot again, this time in her head. She suddenly stops, falls flat on her stomach \n" +
                                "and lies motionless on the polished floorboards. Is she dead? You turn around and begin to \n" +
                                "push the metal door. Just as you see a glimpse of the trees outside, you feel something hard \n" +
                                "hit your head, and you fall over. Your vision begins to fade, you see Ellen standing besides \n" +
                                "you, smiling before everything goes dark.");
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
            return -2;
        }

        int EndPhaseUseUVFlashlight()
        {   // since this ending is exclusive to this option, the entire script of the ending is in the Program.cs file
            return -3;
        }


    }
}
