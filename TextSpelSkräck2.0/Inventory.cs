using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal static class Inventory
    {
        /* 
         * Items list (in order):
         * Basement key     0
         * UV flashlight    1
         * Attic key        2
         * Handgun          3
         * Mysterious key   4
         */
        static List<Item> items = new List<Item>();

        static Inventory()
        {
            items.Add(new Item("Basement key", "The key is made out of something metal, and has rusted, probably because of \n" +
                            "age. The key is labeled “basement“."));
            items.Add(new Item("UV flashlight", "The UV flashlight appears to still be working, however you have no idea for \n" +
                            "how long that will be the case."));
            items.Add(new Item("Attic key", "The attic key is very clean and polished, and does not appear to come from \n" +
                            "this house."));
            items.Add(new Item("Handgun", "The gun appears to be loaded, it could be of use incase that thing mentioned \n" +
                            "in some of the notes would appear"));
            items.Add(new Item("Mysterious key", "The key is somewhat rusty, however it also appears to be in better shape \n" +
                "than the other keys found here. You have no idea what purpose it has."));
        }

        public static void ViewInventory()
        {
            int currentlyUnlockedAmmount = 0;
            int currentlySelectedItem = 0;
            foreach (Item item in items)
            {
                if (item.IsPickedUp && !item.IsConsumed)
                {
                    item.Id = currentlyUnlockedAmmount++;
                }
            }
            if (currentlyUnlockedAmmount <= 0)
            {
                Console.WriteLine("your inventory is currently empty, press any button to return...");
                Console.ReadKey();
                return;
            }

            while (currentlySelectedItem != -1)
            {

                foreach(Item item in items)
                {
                    DisplayUnlockedItem(item, currentlySelectedItem);
                }
                Console.WriteLine("\n" + items[currentlySelectedItem].Description);
                currentlySelectedItem = NavigateInventory(currentlyUnlockedAmmount, currentlySelectedItem);
                Console.Clear();
            }
            foreach (Item item in items)
                item.Id = -1;
        }

        static void DisplayUnlockedItem(Item currentItem, int currentlySelectedItem)
        {
            if (currentItem.Id != -1)
                DisplayItem(currentlySelectedItem, currentItem.Id, currentItem.Name);
        }

        static void DisplayItem(int currentlySelectedItem, int currentItemId, string currentItemName)
        {
            if (currentlySelectedItem == currentItemId)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            Console.WriteLine(currentItemName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

        }
        static int NavigateInventory(int currentlyUnlockedAmmount, int currentlySelectedItem)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            ConsoleKeyInfo pressedButton = Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;

            switch (pressedButton.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    return (currentlySelectedItem <= 0) ? currentlyUnlockedAmmount - 1 : --currentlySelectedItem;

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    return (currentlySelectedItem >= currentlyUnlockedAmmount - 1) ? 0 : ++currentlySelectedItem;

                case ConsoleKey.Escape:
                    return -1;

                default:
                    return currentlySelectedItem;
            }
        }

        static public void UnlockItem(int selectedItem)
        {
            items[selectedItem].IsPickedUp = true;
        }

        static public bool IsPickedUp(int selectedItem)
        {
            return items[selectedItem].IsPickedUp;
        }

        static public bool IsConsumed(int selectedItem)
        {
            return (items[selectedItem].IsConsumed);
        }
        
        // only used for items with 1 time use, for example keys
        static public void ConsumeItem(int selectedItem)
        {
            items[selectedItem].IsConsumed = true;
        }
    }
}
