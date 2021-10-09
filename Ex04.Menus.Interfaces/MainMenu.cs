using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : MenuItem
    {
        public MainMenu(string i_Title, string i_QuitString)
            : base(i_Title)
        {
            QuitString = i_QuitString;
        }

        public List<MenuItem> MenuItemsList { get; } = new List<MenuItem>();

        private string QuitString { get; }

        // $G$ DSN-008 (-5) You should have used polymorphism to implement this (type checking is discouraged)
        public void Show()
        {
            Console.Clear();
            Console.WriteLine(ToString());
            Console.WriteLine("0.{0}", QuitString);
            for(int i = 0; i < MenuItemsList.Count; i++)
            {
                Console.WriteLine("{0}.{1}", i + 1, MenuItemsList[i].Title);
            }

            int userSelection = getUserSelection();

            // $G$ CSS-999 (-1) If you use number as condition --> then you should have use constant here.
            if (userSelection != 0)
            {
                MenuItemsList[userSelection - 1].ParentMenu = this;
                if(MenuItemsList[userSelection - 1] is MainMenu)
                {
                    MenuItemsList[userSelection - 1].Level += 1;
                    (MenuItemsList[userSelection - 1] as MainMenu).Show();
                }
                else
                {
                    MenuItemsList[userSelection - 1].SelectionListeners[0].NotifyListener();
                    Show();
                }
            }
            else
            {
                Level -= 1;
                if(QuitString == "Back")
                {
                    ParentMenu.Show();
                }
            }
        }

        private static int getUserSelection()
        {
            bool validSelection = false;
            int castingUserSelection = -1;
            Console.WriteLine("Please enter your selection: ");

            while(!validSelection)
            {
                string inputUserSelection = Console.ReadLine();
                validSelection = int.TryParse(inputUserSelection, out castingUserSelection);

                if(validSelection)
                {
                    if(!checkInputValid(castingUserSelection))
                    {
                        validSelection = false;
                        Console.WriteLine("Your input is invalid, Please select again ");
                    }
                }
            }

            return castingUserSelection;
        }

        private static bool checkInputValid(int i_UserSelection)
        {
            bool validInput = i_UserSelection == 0 || i_UserSelection == 1 || i_UserSelection == 2;

            return validInput;
        }
    }
}