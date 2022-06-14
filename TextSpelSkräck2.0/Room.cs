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

        public abstract int InsideRoom();
        // summary:
        //      contains the options of a switch that is present in all InsideRoom methods
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

        protected abstract void FirstEntry();

        protected abstract void LookAround();



        public int Id { get { return id; } }
    }
}
