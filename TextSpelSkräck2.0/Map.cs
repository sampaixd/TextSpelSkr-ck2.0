using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal static class Map
    {
        static bool discoveredMainhall;
        static bool discoveredBedroom;
        static bool discoveredKitchen;
        static bool discoveredToolshed;
        static bool discoveredBasementStairs;
        static bool discoveredCell;
        static bool discoveredStorage;
        static bool discoveredWalls;
        static bool discoveredToolshedShortcut;
        static bool discoveredAttic;
        static Map()
        {
            discoveredMainhall = false;
            discoveredBedroom = false;
            discoveredKitchen = false;
            discoveredToolshed = false;
            discoveredBasementStairs = false;
            discoveredCell = false;
            discoveredStorage = false;
            discoveredWalls = false;
            discoveredToolshedShortcut = false;
            discoveredAttic = false;
        }


        static public void ViewMap()
        {
            if (discoveredWalls && discoveredToolshedShortcut) //ifall man har gått genom trapdooren i toolshed
            {
                Console.Write("                Walls--------------------");
            }
            else if (discoveredWalls) //ifall man bara har gått till walls
            {
                Console.Write("                Walls");
            }
            Console.WriteLine("");  //skapar ny rad
            if (discoveredWalls && discoveredToolshedShortcut) //kollar ifall man gått igenom trap door
            {
                Console.Write("                  |                     |");
            }
            else if (discoveredWalls) //ifall man hittat walls
            {
                Console.Write("                  |");
            }
            Console.WriteLine("");
            if (discoveredCell && discoveredStorage) //ifall man varit i båda cells och storage
            {
                Console.Write("       Storage---Cell");
            }
            else if (discoveredCell) //ifall man bara varit vid cells
            {
                Console.Write("                 Cell");
            }
            else
            {
                Console.Write("                   ");   //skapar mellanrum så att attic inte hamnar på fel plats
            }
            if (discoveredAttic)  //ifall man varit i attic
            {
                Console.Write("      Attic");
            }
            else
            {
                Console.Write("           ");
            }
            if (discoveredToolshedShortcut)
            {
                Console.Write("        |");
            }
            Console.WriteLine("");
            if (discoveredCell)  //ifall man upptäckt cell
            {
                Console.Write("                  |");
            }
            else
            {
                Console.Write("                   ");
            }
            if (discoveredAttic)  //ifall man upptäckt attic
            {
                Console.Write("          |");
            }
            else
            {
                Console.Write("           ");
            }
            if (discoveredToolshedShortcut)
            {
                Console.Write("          |");
            }
            Console.WriteLine("");
            if (discoveredBasementStairs)  //ifall man upptäckt basement
            {
                Console.Write("          Basement Stairs");
            }
            else
            {
                Console.Write("                         ");
            }
            if (discoveredKitchen)    //ifall man upptäckt kitchen
            {
                Console.Write("  Kitchen");
            }
            else
            {
                Console.Write("          ");
            }
            if (discoveredToolshedShortcut)
            {
                Console.Write("      |");
            }
            Console.WriteLine("");
            if (discoveredBasementStairs) //om man upptäckt basement
            {
                Console.Write("                  |");
            }
            else
            {
                Console.Write("                   ");
            }
            if (discoveredKitchen)    //ifall man upptäckt kitchen
            {
                Console.Write("          |");
            }
            else
            {
                Console.Write("           ");
            }
            if (discoveredToolshedShortcut)
            {
                Console.Write("          |");
            }
            Console.WriteLine("");
            if (discoveredBedroom && discoveredMainhall && discoveredToolshed)    //ifall man upptäckt bedroom, main hall och toolshed
            {
                Console.Write("               Bedroom---Main hall---Toolshed");
            }
            else if (discoveredBedroom && discoveredMainhall)    //ifall man har upptäckt bedroom och main hall
            {
                Console.Write("               Bedroom---Main hall");
            }
            else if (discoveredMainhall && discoveredToolshed)    //ifall man har upptäckt main hall och toolshed
            {
                Console.Write("                         Main hall---Toolshed");
            }
            else if (discoveredMainhall)     //ifall man har upptäckt main hall
            {
                Console.Write("                         Main hall");
            }

            Console.WriteLine("\n\nLines = rooms you can traverse between");
        }


        static public bool DiscoveredMainHall { get { return discoveredMainhall; } set { discoveredMainhall = value; } }
        static public bool DiscoveredBedroom { get { return discoveredBedroom; } set { discoveredBedroom = value; } }
        static public bool DiscoveredKitchen { get { return discoveredKitchen; } set { discoveredKitchen = value; } }
        static public bool DiscoveredToolshed { get { return discoveredToolshed; } set { DiscoveredToolshed = value; } }
        static public bool DiscoveredBasementStairs { get { return discoveredBasementStairs; } set { discoveredBasementStairs = value; } }
        static public bool DiscoveredCell { get { return discoveredCell; } set { discoveredCell = value; } }
        static public bool DiscoveredStorage { get { return discoveredStorage; } set { discoveredStorage = value; } }
        static public bool DiscoveredWalls { get { return discoveredWalls; } set { discoveredWalls = value; } }
        static public bool DiscoveredToolshedShortcut { get { return discoveredToolshedShortcut; } set { discoveredToolshedShortcut = value; } }
        static public bool DiscoveredAttic { get { return discoveredAttic; } set { discoveredAttic = value; } }

    }
}
