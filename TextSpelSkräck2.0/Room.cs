﻿using System;
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

        protected string GoToAndPickUpFormatting(string[] insertedCommand)
        {
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
