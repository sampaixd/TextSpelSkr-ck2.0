using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Room> rooms = GenerateRooms();
            Prologue();
            int currentRoom = 0;
            while (currentRoom != -1)
            {
                foreach (Room room in rooms)
                {
                    if (room.Id == currentRoom)
                    {
                        currentRoom = room.InsideRoom();
                        break;
                    }
                }
            }
        }

        static void TestMethod()
        {
            DocumentManager.UnlockDocument(1);
            DocumentManager.UnlockDocument(3);
            DocumentManager.UnlockDocument(5);
            DocumentManager.UnlockDocument(2);
            DocumentManager.UnlockDocument(11);

            DocumentManager.ViewDocuments();

        }


        static List<Room> GenerateRooms()
        {
            Console.WriteLine("Loading game...");

            List<Room> rooms = new List<Room>();
            
            rooms.Add(new Mainhall());

            Console.WriteLine("Game loaded, press any key to start");
            Console.ReadKey();
            return rooms;
        }
        static void Prologue()
        {
            Console.WriteLine("Ever since she disappeared my life has been empty. Ellen, my wife disappeared 2 years ago \n" +
                        "during one of her work trips. However, she never reached her destination. The company she \n" +
                        "was supposed to interview never saw her, or had even heard of her for that matter. Her \n" +
                        "golden and luxurious hair, her eyes shining like sapphires and her smile glowing like the sun. \n" +
                        "Gone, she now only existed through our many photos taken together and in my memories.");
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Until recently, when I received a letter from her, containing a destination and asking me to \n" +
                "pick her up. I immediately picked up the car keys and entered the car, not hesitating for a \n" +
                "second. During the entire ride, my head was filled with questions. Where had she been? \n" +
                "Why didn’t she contact me sooner? Filled with the excitement to see her again, and the \n" +
                "questions filling my head to the brim I was completely blind of the fact that something was \n" +
                "wrong, something simply didn’t add up. Would I have acted differently if I would’ve had a \n" +
                "clear mind? No, there’s no way I could’ve seen what was lying ahead of me, the horrors that \n" +
                "I experienced were nothing that any sane person would ever imagine.");
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("As I kept driving, the sun slowly disappeared over the horizon, the interval between houses \n" +
                "got larger and larger, and the trees got more dense for every kilometer. By the time I had \n" +
                "reached my destination, I hadn’t seen any sign of civilization for hours, the safety of the sun \n" +
                "was long gone, replaced by a full moon dimmed by thick dark clouds. The forest caged me \n" +
                "in, with its dark, bulky trunks and the naked branches with its sharp long claws, waving in the \n" +
                "wind and slowly reaching after me.");
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
