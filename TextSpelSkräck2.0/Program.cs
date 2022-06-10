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
            List<Room> rooms = new List<Room>();

            rooms.Add(new Mainhall());
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
    }
}
