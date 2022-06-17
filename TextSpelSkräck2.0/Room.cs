using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal abstract class Room
    {
        protected string name;
        protected int id;
        public Room(string name, int id)
        {
            this.name = name;
            this.id = id;
        }

        public virtual int InsideRoom()
        {
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
        /// <summary>
        ///      contains the options of a switch that is present in all InsideRoom methods
        /// </summary>
        protected virtual void InsideRoomBaseSwitch(string userInput)
        {
            switch(userInput)

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

        protected string GoToAndPickUpFormatting(string[] insertedCommand)
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

        protected abstract int GoToCommand(string room);

        protected string InspectAndUseFormatting(string[] insertedCommand)
        {
            string formattedString = "";
            for (int i = 1; i < insertedCommand.Length; i++)
            {
                formattedString += insertedCommand[i] + " ";
            }
            return formattedString.Remove(formattedString.Length - 1);  // removes the last character
        }
        protected abstract void InspectCommand(string inspectedObject);

        protected abstract void PickUpCommand(string item);

        protected abstract void UseCommand(string item);

        protected abstract void FirstEntry();

        protected abstract void LookAround();



        public int Id { get { return id; } }
    }
}
