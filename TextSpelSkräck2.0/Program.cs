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
            TestMethod(rooms);
            Prologue();
            int currentRoom = 0;
            while (currentRoom >= 0)
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
            switch(currentRoom)
            {
                case -1:
                    CarEnding();
                    break;

                case -2:
                    AtticBadEnding();
                    break;

                case -3:
                    AtticGoodEnding();
                    break;

                case -4:
                    SecretEnding();
                    break;
            }
            Console.WriteLine("Thank you for playing!");
            Console.WriteLine("Press any key to exit the game");
            Console.ReadKey();
        }

        static void TestMethod(List<Room> rooms)
        {
            Cell test = new Cell();
            //DocumentManager.UnlockDocument(0);
            Inventory.ConsumeItem(2);
            test.InsideRoom();
            

        }


        static List<Room> GenerateRooms()
        {
            Console.WriteLine("Loading game...");

            List<Room> rooms = new List<Room>();

            // rooms are added in order of their id
            rooms.Add(new Outdoors());
            rooms.Add(new Mainhall());
            rooms.Add(new Bedroom());
            rooms.Add(new Kitchen());
            rooms.Add(new Toolshed());
            rooms.Add(new BasementStairs());
            rooms.Add(new Cell());

            Console.WriteLine("Game loaded, press any key to start");
            Console.ReadKey();
            Console.Clear();
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

        static void CarEnding()
        {
            Console.WriteLine("You take one last look into the old estate, with your dead wife meeting your gaze. Her mouth, \n" +
                "as if her soul had left her body. Her terrified, lifeless eyes drilling deep into your soul before \n" +
                "you violently shut the door. Breathing heavily, not only from all the madness you’ve n" +
                "witnessed but also the sorrow of having to leave her like this, you walk towards the car. \n" +
                "Fondling your keys with great difficulty, you finally manage to unlock the car and sit back \n" +
                "down on the soft car seat. ");
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
            
            Console.WriteLine("While trying to insert the car key into the ignition, the door to the estate is slowly pushed \n" +
                "aside. Standing in the entrance you see Ellen, Hunched over and her arm lifelessly dangling \n" +
                "by her sides. At first you feel a sense of liberation spread through your chest, it wasn’t Ellen \n" +
                "hanging there after all. Then immediately, that warm feeling gets replaced by a gripping cold, \n" +
                "as you notice her face. It’s the same as the one that was hanging in the chandelier, with the \n" +
                "terrified and lifeless eyes staring at you. However, being shaped as if from a horrified \n" +
                "scream, Her mouth formed a twisted smile, running from cheek to cheek, like a wolf who \n" +
                "finally cornered their prey. You quickly turn the key in the ignition, only to be met by silence. \n" +
                "You frantically turn the key back and forth, praying to hear the engine roar but to no avail. As \n" +
                "you look up, the creature is only one or two meters away from the car. The smell of coal \n" +
                "starts filling your nostrils as its almost robotic movements closes the gap between you and it. ");
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
            
            Console.WriteLine("Finally you hear the engine roaring. You stomp down the pedal, quickly backing off away \n" +
                "from the estate. As soon as you get the opportunity, you spin the car around, and with your \n" +
                "back to the estate a relieving feeling spreads through your chest. Looking through the \n" +
                "rearview mirror, you see the thing standing there, staring at you in the distance. You keep an \n" +
                "eye on it until the overgrown branches and trees block the view between you and that thing. ");
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
            
            Console.WriteLine("During the entire ride home the only thing that occupies your mind is the face of that \n" +
                "creature. It had the face of Ellen, however it clearly wasn’t her. The eyes stick like a knife in \n" +
                "your mind, giving you a constant uncanny feeling of being watched. That feeling sticks until \n" +
                "you finally reach your home. By this time, the moon stands tall in the sky, and the street is \n" +
                "completely devoid of life. You park the car in the garage, walk over to the front door, walking \n" +
                "over the grass instead of using the tiles. As you struggle to put in the key into the keyhole, \n" +
                "you cannot shake the feeling of being watched still, which doesn’t make getting the key to fit \n" +
                "any easier. When you finally manage to unlock the door, you quickly enter the house, turn \n" +
                "around and lock the door instantly. ");
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Your body feels heavier for each step you take, as you slowly approach the bedroom. \n" +
                "Pushing the door open, and then shutting it behind, you fall into the bed, feeling too fatigued \n" +
                "to move even an inch. As you lay there, defenseless, you start hearing things. At first you \n" +
                "think it’s just the bushes getting dragged along by the wind, but slowly realize that the sound \n" +
                "is too heavy and too methodical. Suddenly it stops, about where the kitchen would be \n" +
                "located. Then you hear the sound of someone walking slowly over the kitchen floor. You try \n" +
                "to move, however the fatigue as well as the dread spreading through every limb freezes your \n" +
                "every muscle. As the steps slowly approach the bedroom, the suffocating smell of coal starts \n" +
                "filling the room, crawling its way into your body. Laying there motionless, exhausted and \n" +
                "terrified to your core, you watch as the bedroom door slowly but surely opens with a \n" +
                "dreading creak. Within the thick layer of darkness behind the door, your gaze meets 2 \n" +
                "lifeless, cold eyes as well as a wicked smile, like a wolf who finally cornered their prey.");
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        

        static void AtticBadEnding()
        {
            Console.WriteLine("As you slowly gain consciousness, you feel a tight grip on your left foot as well as the damp \n" +
                "floorboards grinding against your back. As you open your eyes, you see Ellen dragging you \n" +
                "towards the basement, however you do not have the power left to fight back. In fact, you \n" +
                "cannot move at all, being forced to watch as you slowly get dragged down into the darkness.");
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        static void AtticGoodEnding()
        {
            Console.WriteLine("You bring up your UV flashlight, and start aiming it towards your wife. However, the flashlight \n" +
                "does not turn on, despite you pressing the button. You try pressing it multiple times as Ellen \n" +
                "slowly walks closer and closer towards you. Eventually, you give the flashlight a whack \n" +
                "which finally turns on the UV light. As soon as the light reaches Ellen, she starts screaming \n" +
                "as smoke begins to form around her as the skin begins to corrode. She makes a last \n" +
                "desperate attempt to reach you, however she falls flat before you as she keeps screaming. \n" +
                "Her skin begins to turn black and into ash. You keep shining the flashlight until she \n" +
                "stops screaming, and as you turn off the flashlight you see her body slowly fall apart and \n" +
                "slowly fading away, like dandelion seeds blowing away in the hot summerwind. Once there is \n" +
                "nothing but ashes scattered around the room left, you continue to push open the door. \n" +
                "Eventually, it gives in, revealing a way out to the roof with a ladder. As you walk down the \n" +
                "ladder, you find yourself behind the estate. You go around to see your car again, hop inside \n" +
                "and take a last good look at the Campbell estate before you turn on the motor, and drive \n" +
                "back home. ");
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        static void SecretEnding()
        {
            throw new NotImplementedException();
        }
    }
}
