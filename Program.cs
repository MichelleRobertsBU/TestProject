﻿using Newtonsoft.Json;

//EmilysArtInventory

namespace EmilysArtInventory
{

    class MainClass
    {
        static List<MenuItem> menuItems = new List<MenuItem>();
        static List<string> painting;

        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Emily's Gallery Inventory");
            Console.WriteLine();

            {
                var json = File.ReadAllText("Paintings.json");
                painting = JsonConvert.DeserializeObject<List<string>>(json);


                menuItems.Add(new MenuItemAddNewPainting());
                menuItems.Add(new MenuItemRemovePainting());
                menuItems.Add(new MenuItemNumberofPaintings());
                menuItems.Add(new MenuItemExit());

                var keepGoing = true;

                while (keepGoing)
                {
                    keepGoing = MainMenu();
                }

                Console.WriteLine("Press any key to exit!");
                Console.ReadKey();
                Console.WriteLine("Program exited");
            }
        }

        public static bool MainMenu()
        {
            string message = null;
            if (message is not null)
            {
                Console.WriteLine(message.Length);
            }
            foreach (string p in painting)
            {
                Console.WriteLine(p);
            }

            // show user a menu
            Console.WriteLine();
            Console.WriteLine("Main Menu:");

            for (int i = 0; i < menuItems.Count; i++)
            {
                MenuItem item = menuItems[i];
                Console.WriteLine($"{i}. {item.Choice}");
            }
            Console.WriteLine();
            Console.Write("Enter your choice: ");
            // ask for their choice
            int userChoice = Library.GetNumber();

            Console.WriteLine("");

            if (userChoice < menuItems.Count)
            {
                return menuItems[userChoice].ExecuteChoice(painting);
            }
            else
            {
                Console.WriteLine($"You have input the choice '{userChoice}'.");
                Console.WriteLine("That isn't valid, try again.");
                return true;
            }
        }
    }

}
