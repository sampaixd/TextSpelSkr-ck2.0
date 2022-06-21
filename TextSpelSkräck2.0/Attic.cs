using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal class Attic : Room
    {
        public Attic() : base("Attic", 9)
            { }

        public override int InsideRoom()
        {
            if (!Map.DiscoveredAttic)
                FirstEntry();

            return base.InsideRoom();
        }
        protected override void FirstEntry()
        {
            Console.WriteLine("You slowly climb up the metallic stairs up into the attic.");
            Console.WriteLine("Attic added to map");
            Console.WriteLine("\nPress any key to continue");
            Map.DiscoveredAttic = true;
            Console.ReadKey();
            Console.Clear();
        }

        protected override int GoToCommand(string room)
        {
            switch(room)
            {
                case "kitchen":
                case "downstairs":
                case "ladder":
                case "down ladder":
                    return 3;

                case "door":
                case "exit":
                case "end of the room":
                case "metallic door":
                case "escape":
                    return EndPhase();

                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    return id;
            }
        }

        protected override void InspectCommand(string inspectedObject)
        {
            switch(inspectedObject)
            {
                case "gun":
                case "document":
                    PickupGun();
                    break;

                case "computer":
                case "terminal":
                case "computer terminal":
                case "computerterminal":
                    UseComputer();
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
                case "gun":
                case "document":
                    PickupGun();
                    break;

                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    break;
            }
        }

        protected override void UseCommand(string item)
        {
            switch (item)
            {
                case "computer":
                case "terminal":
                case "computer terminal":
                case "computerterminal":
                    UseComputer();
                    break;

                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    break;
            }
        }

        void PickupGun()
        {
            if (Inventory.IsPickedUp(3))
            {
                Console.WriteLine("You have already picked up the items on the table");
                return;
            }

            Console.WriteLine("You walk up to the table and look at the gun and the document. You pick up both, and check \n" +
                                "if the gun is loaded. It appears to have a full magazine in it. You begin to read the document, \n" +
                                "which like the other documents found on soldiers have been printed out rather than written \n" +
                                "by hand.");
            Console.WriteLine("\n" + DocumentManager.Content(11));
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("After picking up the document, you notice there is an opened letter. The handwriting looks \n" +
                "just like Ellens.");
            Console.WriteLine("\n" + DocumentManager.Content(10));
            Console.WriteLine("\nMission briefing operation gestalt added to documents");
            Console.WriteLine("\nGun added to inventory");
            Console.WriteLine("\nunsent letter from Ellen added to documents");
            Console.WriteLine("\nPress any key to continue");
            DocumentManager.UnlockDocument(11);
            DocumentManager.UnlockDocument(10);
            Inventory.UnlockItem(3);
            Console.ReadKey();
            Console.Clear();
        }

        void UseComputer()
        {

        }
        int EndPhase()
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
            {
                attempts = EndPhaseGetAction();
            }

            return id;
        }

        int EndPhaseGetAction(int currentAttempt)
        {
            string userInput = Console.ReadLine();
            userInput = userInput.ToLower();
            string[] userInputArr = userInput.Split(' ');
            Console.Clear();
            switch(userInputArr[0])
            {
                case "go":
                    EndPhaseGoToCommand(GoToAndPickUpFormatting(userInputArr));
                    break;

                case "inspect":
                    EndPhaseInspectCommand(InspectAndUseFormatting(userInputArr));
                    break;
                
                case "pick":
                    EndPhasePickUpCommand(GoToAndPickUpFormatting(userInputArr));
                    break;

                    
                case "use":     // this is the only option that can give you some kind of ending early
                    return EndPhaseUseCommand(InspectAndUseFormatting(userInputArr));
            }
            Console.WriteLine("Ellen is slowly getting closer...");
            return ++currentAttempt;
        }

        void EndPhaseGoToCommand(string input)
        {
            switch (input)
            {
                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    break;
            }
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
            switch(input)
            {
                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    break;
            }
        }

        int EndPhaseUseCommand(string input)
        {
            switch(input)

            {
                case "gun":
                case "weapon":
                case "pistol":
                    EndPhaseUseGun();
                    return 5;

                default:
                    Console.WriteLine("invalid input, please type \"help\" to get a list of avalible options");
                    Console.WriteLine("Ellen is slowly getting closer...");
                    return id;

            }
                
        }

        void EndPhaseUseGun()
        {

        }


        protected override void LookAround()
        {
            Console.Write("The walls and floor appear to have been recently renovated, as well as the ceiling with \n" +
                            "pristine planks all around you. In the middle of the attic you see a large round table. ");

            if (!Inventory.IsPickedUp(3))
                Console.Write("On top \n" +
                                "of the table there is a document, and next to the document you see a gun. ");
            
            Console.WriteLine("There is also a \n" +
                                "computer terminal on the table, with something written on the screen. At the other side \n" +
                                "of the attic, there is a metallic door, probably the secret escape route that was mentioned in \n" +
                                "the other document. This place has definitely been a place of operations before.");
            
        }
    }
}
