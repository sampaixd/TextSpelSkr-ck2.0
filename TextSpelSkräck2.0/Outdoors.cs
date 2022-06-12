using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSpelSkräck2._0
{
    internal class Outdoors : Room
    {
        public Outdoors() : base("outdoors", 0)
        { }

        public override int InsideRoom()
        {
            if (!Inventory.IsConsumed(4))
            {
                FirstEntry();
                return 1;
            }
            throw new NotImplementedException();
        }


        protected override void FirstEntry()
        {
            Console.WriteLine("The car door groans as you slowly open it, letting the cold air caress your face. You put your \n" +
            "left foot onto the damp dirt, feeling it trying to swallow your shoe. As you stand up, you finally \n" +
            "see the Campell estate resting before you. The foreign estate is made out of dark molded \n" +
            "planks, with many being bent or broken in different places. What appears to be windows \n" +
            "have been bordered up, making it impossible to see what the estate is hiding. A couple \n" +
            "meters in front of you there is a wooden door swinging freely in the wind, inviting you to \n" +
            "come in.");
            Console.WriteLine("\nType 'go to entrance' to enter the house");
            bool loop = true;
            string input;
            while (loop)
            {
                input = Console.ReadLine();
                input = input.ToLower();
                switch (input)
                {
                    case "go to front door":
                    case "go to door":
                    case "go inside":
                    case "go to house":
                    case "go to entrance":
                        loop = false;
                        break;

                    case "look around":
                        Console.WriteLine("The estate appears to have been around for a long time, with dark planks covering the walls \n" +
                            "as well as the windows. As the wind passes by, the estate appears to shiver, slowly dancing \n" +
                            "back and forth all alone in the forest. It looks like the house has only 1 story, with perhaps a \n" +
                            "basement as well as an attic. In the front, there is a small porch with the door swinging freely \n" +
                            "in the wind. As you walk onto the porch, you notice a pool of blood to the side, with blood \n" +
                            "seeping through the planks going under the porch. Something is definitely wrong here, \n" +
                            "however you cannot go back without Ellen.");
                        break;

                    default:
                        Console.WriteLine("Invalid input, try typing 'go to entrance' to enter the estate");
                        break;

                }
            }
        }
        protected override void LookAround()
        {
            throw new NotImplementedException();
        }
    }
}
