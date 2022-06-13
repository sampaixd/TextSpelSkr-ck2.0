using System;
using System.Collections.Generic;

namespace TextSpelSkräck2._0
{
    internal static class DocumentManager
    {
        static List<Document> documents = new List<Document>();

        /*
         * documents (in order)
         * Letter from Ellen                                0
         * Blood stained document (Main hall)               1
         * Blood stained note (Toolshed)                    2
         * Recipe for homemade bread (Kitchen)              3
         * Mysterious note (Cell)                           4
         * Notes about 'it' (Storage)                       5
         * Information regarding UV light (Walls)           6
         * Number habits with G001(Toolshed)                7
         * Escape route (Main hall)                         8
         * List of members operation Gestalt (Toolshed)     9
         * Unsent letter from Ellen (Attic)                 10
         * Mission Briefing operation Gestalt (Attic)       11
         */
        static DocumentManager()
        {
            documents.Add(new Document("Letter from Ellen", "A letter sent from Ellen, after 2 years of silence",
                "Dear James \n\nDulvey, Lousiana \n\nCampell estate \n\nCome pick me upp \nLove, Ellen"));

            documents.Add(new Document("Blood stained document (Main hall)", "A document found in the main hall. \n" +
                "The blood has almost entirely destroyed the document, making it nigh impossible to read its content",
                "M------ -- -p------- ---t--- " +
                "\n-eb------ ----- ---l- --------t " +
                "\n---- ---e- ----i--- --- ---------n" +
                "\n---e- ------o- --c----- --d -r--------"));

            documents.Add(new Document("Blood stained note (Toolshed)", "The note is partly covered in blood, however some parts are still readable",
                "How did --------" +
                "\nlocked in the basem----- bedroom" +
                "\nmust be s---------" +
                "\n------- fl-----------" +
                "\n---------------------"));

            documents.Add(new Document("Recipe for homemade bread (Kitchen)", "It is a recipe for making homemade bread. \n" +
                "Ellen used to make the most delicious homemade bread back then",
                "Recipe for making delicious homemade bread:" +
                "\n\nflour: 9 dl" +
                "\nyeast: 1 spoonful" +
                "\nsalt: 2 teaspoons" +
                "\nwater: 5 dl" +
                "\n\n1. Put the yeast in a bowl." +
                "\n2. Heat up the water up to 37 Degrees and pour it into the bowl, stir until the yeast has dissolved." +
                "\n3. Add salt and half of the flour, stir with considerable force." +
                "\n4. Add the rest of the flour slowly while stirring the bowl stimuntaneusly. Stir until the dough is smooth." +
                "\n5. Let the dough ferment under a towel for 20 minutes." +
                "\n6. Work the dough and let it ferment for an additional 20 minutes." +
                "\n7. Knead a couple minutes on a flour covered baking breadboard." +
                "\n8. Split up and shape the dough into round or oblong pieces." +
                "\n9. Put the dough onto an anointed baking sheet." +
                "\n10. Let the bread ferment for 20 minutes." +
                "\n11. Bake the bread for 8 minutes in 250 degrees, and for 15 minutes in 225 degrees if you made them oblong." +
                "\n12. Let the bread cool down on a grid with or without a towel."));

            documents.Add(new Document("Mysterious note (Cell)", "It appears to be some sort of riddle, \n" +
                "I wonder if this has any connection to the codelock on the cell?",
                "Where the family gathers 3 times a day" +
                "\nThe key can be found surrounded by knowledge" +
                "\nWhen all the items are put in order, the door will open"));

            documents.Add(new Document("Notes about 'it' (Storage)", "If it wouldn't have been for all the weird and unexplainable \n" +
                "things in this house, I would probably have written this off as some kind of maniacs scribbling",
                "that thing aPpears to be using the walls to move around, which wOuld explain how it could eScape the " +
                "\nbasement when they first locked it in. To make matters worse, this shows that thE thing can not only traverse the " +
                "\nhouse without being detected, but can also be used to stalk people without being noticed. scaRy thought."));

            documents.Add(new Document("Information regarding UV light (Walls)", "information about the UV flashlight. \n" +
                "Some parts of the document are covered in blood and therefore unreadable",
                "Use of the UV flashlight \n\n" +
                "As mentioned in the briefing, the UV flashlight was used to find the victims. Luckily, the \n" +
                "property of poison negating coalition of the blood has proved it much easier to find the \n" +
                "hidden corpses. Also remember that if necessary, using th- ------- ----------- ------ -- ------\n" +
                "--------------------- ---------------- ------ ------ ----- ----- ---------- ----------- -----------"));

            documents.Add(new Document("Number habits with G001(Toolshed)", "this \"G001\" has to be the thing mentioned in that other document. This however appears to \n" +
                "be the results from some sort of experiment. Now I'm sure something happened here, and \n" +
                "I’m afraid it went horribly wrong",
                "Report 19th June 2018 \n" +
                "In our most recent experiment, we gave the subject a math book for kindergarten to see how \n" +
                "it would respond. After giving it a pen and paper, it did not only know how to successfully \n" +
                "write with a pen, but also writing numbers in a weird pattern. All I’ve seen from the writings \n" +
                "so far is that they’re always uneven and in order with the smallest number first and the \n" +
                "biggest number last. For example, one of the papers spelled out -7, -3, 1, 3, 3, 5, 7. I will \n" +
                "continue to monitor it’s behaviour to see if I notice anything new. \n\n" +
                "Report 21st June 2018 \n" +
                "After further investigation, it appears that the numbers written if added together always turn \n" +
                "into 9. For example, with the numbers it wrote 2 days ago(-7, -3, 1, 3, 3, 5, 7) if you add all \n" +
                "of them together you will get the number 9.Further experimentation will be required to figure \n" +
                "out the origin of this odd habit. \n\n" +
                "How did it know the combination?? Every time I entered the password Ellen was making \n" +
                "sure it was not watching us. It must have some sort of new \n" +
                "trick that we aren’t aware of. I managed to escape for now, However i fear that if it catches \n" +
                "me, I’m done for. We need to regroup if we want to survive, I need to find the others, now!"));

            documents.Add(new Document("Escape route (Main hall)", "Oh god, I don’t want to believe in what I saw. How could this happen to you? The document \n" +
                "mentions an escape route, but can I really leave you like this?",
                "Since doors and windows are locked to make sure that the subject does not escape \n" +
                "containment, we’ve implemented a secret escape route in the attic. To make sure that the \n" +
                "subject is unable to use the attic to escape, you are all given a key that will unlock the code \n" +
                "lock in the kitchen. Make sure to commit the code to memory: 831. In case the subject would \n" +
                "in any matter gain hold of the password, it can be changed simply by inserting the password \n" +
                "twice and then inserting the new password."));

            documents.Add(new Document("List of members operation Gestalt (Toolshed)", "Ellen is on this list. Why were you hiding this from me?",
                "Members of Operation Gestalt: \n\n" +
                "Sebastian Smith: Field Scientist \n" +
                "John Baker: Security and protection \n" +
                "Ellen Thompson: Security and protection"));

            documents.Add(new Document("Unsent letter from Ellen (Attic)", "It is an unsent letter from Ellen. Why did she change her mind and send me the location \n" +
                "instead?",
                "Dear James \n" +
                "I know that I shouldn't have lied to you, that I should’ve told you the truth. However, it is too \n" +
                "late for that now, just know that if you get this letter, that I am gone. Don’t look for me, forget \n" +
                "that I ever existed and if you ever get any letter or mail from me, know that it is not me, know \n" +
                "that it is something far more sinister and dangerous than you can ever imagine. I’m sorry \n" +
                "that it had to end like this. \n" +
                "Love, Ellen"));

            documents.Add(new Document("Mission Briefing operation Gestalt (Attic)", "It’s a mission brief over operation “Gestalt”. What the fuck were you dragged into Ellen?",
                "Our agents have picked up strange happenings in the Campell estate, as well as a missing \n" +
                "person. Your job is to go to the location, set up a room of operations as well as necessary \n" +
                "testing equipment, and inspect the anomaly, also known as G001 to gather information. The \n" +
                "job of Sebastian Smith is to set up all the necessary equipment, as well as studying and \n" +
                "giving frequent reports on the behaviour of G001. The job of John Baker and Ellen \n" +
                "Thompson is to protect Sebastian Smith and if necessary, neutralize G001. You will be given \n" +
                "enough firepower to take down an entire army, however we do not know if normal gunfire \n" +
                "will be of any effect. Therefore, you will also be given a UV flashlight, as the preparation \n" +
                "team managed to reveal the corpse of the former owner using a UV flashlight. It is only a \n" +
                "theory at the moment, but the UV light could prove to be an effective weapon."));

            documents[0].IsPickedUp = true; // you start with this unlocked
        }


        public static void ViewDocuments()
        {
            int currentlyUnlockedAmmount = 0;
            int currentlySelectedDocument = 0;
            foreach (Document document in documents)
            {
                if (document.IsPickedUp && !document.IsConsumed)
                {
                    document.Id = currentlyUnlockedAmmount++;
                }
            }

            while (currentlySelectedDocument != -1)
            {

                foreach (Document document in documents)
                {
                    DisplayUnlockedItem(document, currentlySelectedDocument);
                }
                Console.WriteLine("\n" + documents[currentlySelectedDocument].Description);
                currentlySelectedDocument = NavigateDocuments(currentlyUnlockedAmmount, currentlySelectedDocument);
                Console.Clear();
            }
        }

        static void DisplayUnlockedItem(Document currentDocument, int currentlySelectedDocument)
        {
            if (currentDocument.Id != -1)
                DisplayDocument(currentlySelectedDocument, currentDocument.Id, currentDocument.Name);
        }

        static void DisplayDocument(int currentlySelectedDocument, int currentDocumentId, string currentDocumentName)
        {
            if (currentlySelectedDocument == currentDocumentId)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            Console.WriteLine(currentDocumentName);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

        }

        static int NavigateDocuments(int currentlyUnlockedAmmount, int currentlySelectedDocument)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            ConsoleKeyInfo pressedButton = Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;

            switch (pressedButton.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    if (currentlySelectedDocument <= 0)
                        return currentlyUnlockedAmmount - 1;
                    return --currentlySelectedDocument;


                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    if (currentlySelectedDocument >= currentlyUnlockedAmmount - 1)
                        return 0;
                    return ++currentlySelectedDocument;

                case ConsoleKey.Enter:
                    ViewContent(currentlySelectedDocument);
                    return currentlySelectedDocument;

                case ConsoleKey.Escape:
                    return -1;

                default:
                    return currentlySelectedDocument;
            }
        }

        static void ViewContent(int selectedDocument)
        {
            Console.Clear();
            Console.WriteLine(documents[selectedDocument].Content);
            Console.WriteLine("\nPress any key to return to previous menu");
            Console.ReadKey();
        }

        public static bool IsPickedUp(int selectedDocument)
        {
            return documents[selectedDocument].IsPickedUp;
        }

        public static string Content(int selectedDocument)
        {
            return documents[selectedDocument].Content;
        }

        public static void UnlockDocument(int selectedDocument)
        {
            documents[selectedDocument].IsPickedUp = true;
        }

       
    }
}
