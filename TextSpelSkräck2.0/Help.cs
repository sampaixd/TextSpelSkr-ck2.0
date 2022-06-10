using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal class Help
    {
        public static void HelpMenu()
        {
            Console.WriteLine("--- means that you have to specify the item/location/object");
            Console.WriteLine("go to ---      goes to a specified location");
            Console.WriteLine("look around    look around the room you're currently in");
            Console.WriteLine("pick up ---    picks up a specified item");
            Console.WriteLine("inspect ---    gives more detail about a specific object or item, will sometimes pick up items or documents you find");
            Console.WriteLine("The game will always tell you whenever you pick up an item or document");
            Console.WriteLine("use ---    uses a item or interacts with a puzzle");
            Console.WriteLine("inventory    shows a list of all your items");
            Console.WriteLine("documents/document    shows a list of all your documents");
            Console.WriteLine("map    shows you a map of the area");
            Console.WriteLine("You can navigate your inventory and documents using W/S or arrow up/arrow down and enter to inspect an item. You exit your intentory/documents by pressing escape");
            Console.WriteLine("You can also inspect the document or the item using the inspect action");
        }
    }
}
