using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal class Attic : Room
    {
        bool computerIsUnlocked;
        int computerUnlockAttempts;
        public Attic() : base("Attic", 9)
        {
            computerUnlockAttempts = 0;
            computerIsUnlocked = false;
        }

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
                    AtticEndPhase endPhase = new AtticEndPhase();
                    return endPhase.EndPhase();

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
                case "weapon":
                case "pistol":
                case "document":
                case "note":
                case "paper":
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
                case "weapon":
                case "pistol":
                case "document":
                case "note":
                case "paper":
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
                    UseComputerRequirements();
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

        void UseComputerRequirements()
        {
            if (computerUnlockAttempts >= 3)
            {
                Console.WriteLine("You walk to the computer and look at what is on the screen.There is a green text that says \n" +
                                "“Terminal locked, please bring the computer to the responsible IT personnel”. It doesn’t \n" +
                                "appear that you can unlock this computer anymore.");
            }
            else if (computerIsUnlocked)
            {
                UseComputer();
            }
            else
            {
                Console.WriteLine("You walk to the computer and look at what is on the screen. There is a green text that says \n" +
                    "“username:”, waiting for an input. You lean over and put your hands on the keyboard.");
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();
                AttemptToUnlockComputer();

            }
            Console.ForegroundColor = ConsoleColor.White;


        }

        void AttemptToUnlockComputer()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            while (computerUnlockAttempts < 3)
            {
                Console.Write("username: ");
                string userName = Console.ReadLine();
                if (userName == string.Empty)
                {
                    Console.Clear();
                    return;
                }

                string password = GetPassword();
                if (password == string.Empty)
                {
                    Console.Clear();
                    return;
                }

                if (userName == "gamp" && password == "inplanesight")
                {
                    Console.Clear();
                    UnlockComputer();
                    return;
                }
                else
                {
                    computerUnlockAttempts++;
                    Console.Clear();
                    Console.WriteLine("Incorrect username or password, press any key to try again");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
            Console.WriteLine("Terminal locked, please bring the computer to the responsible IT personnel");
            Console.ReadKey(true);
            Console.Clear();
        }

        string GetPassword()
        {
            Console.Write("password: ");
            string password = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    return password;
                
                else if (key.KeyChar == '\b')
                {
                    if (password.Length > 0)
                    {
                        password = password.Remove(password.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (key.Key == ConsoleKey.Escape)
                    return "";
                
                else
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            }
        }

        void UnlockComputer()
        {
            Console.WriteLine("Login accepted");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
            computerIsUnlocked = true;
            UseComputer();
        }


        void UseComputer()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Welcome user\n");
            Console.ReadLine();

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
