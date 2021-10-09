using System;
using System.Collections.Generic;
using System.Text;

// $G$ DSN-001 (-5) You should create a MainMenu class in this project.
// $G$ DSN-008 (-5) You should have used polymorphism to implement the different behavior between a sub menu and the main menu.

namespace Ex04.Menus.Delegates
{
    public class Menu
    {
        private readonly List<MenuChoice> r_Choices;
        private readonly Menu r_Root;
        private readonly string r_Title;

        public Menu(string i_Title, List<MenuChoice> i_Choices, Menu i_Root)
        {
            r_Title = i_Title;
            r_Choices = i_Choices;
            if(i_Root != null)
            {
                Level = i_Root.Level + 1;
            }

            r_Root = i_Root;
        }

        private int Level { get; }

        public void Show()
        {
            Console.Clear();
            printMenu();
            int choice = getUserChoice();
            // $G$ DSN-999 (-2) Good only for 3 option menu.
            if (choice == r_Choices.Count - 2)
            {
                r_Root?.Show();
            }
            else
            {
                Action action = r_Choices[choice - 1].Action;
                if(action != null)
                {
                    Console.Clear();
                    action();
                    if(r_Root != null)
                    {
                        Show();
                    }
                }
                else
                {
                    Console.WriteLine("Not implemented yet, press a key to continue.");
                    Console.ReadKey();
                    Show();
                }
            }
        }

        private void printMenu()
        {
            Console.WriteLine(ToString());
            Console.WriteLine("0.{0}", r_Root == null ? "Exit" : "Back");

            for(int i = 0; i < r_Choices.Count; i++)
            {
                Console.WriteLine("{0}.{1}", i + 1, r_Choices[i].Title);
            }
        }

        public override string ToString()
        {
            StringBuilder menuDescription = new StringBuilder();
            menuDescription.AppendLine(string.Format("{0}:", r_Title));
            menuDescription.AppendFormat("The level now is: {0}", Level);
            return menuDescription.ToString();
        }

        private int getUserChoice()
        {
            Console.WriteLine("Please enter your selection: ");
            getChoice(out int menuItemSelected);
            while(menuItemSelected < 0 || menuItemSelected > r_Choices.Count)
            {
                Console.WriteLine();
                Console.WriteLine("Please try again");
                getChoice(out menuItemSelected);
            }

            return menuItemSelected;
        }

        private static void getChoice(out int o_Choice)
        {
            int.TryParse(Console.ReadLine(), out o_Choice);
        }
    }
}