using System.Collections.Generic;
using Ex04.Menus.Delegates;

// $G$ SFN-003 (-7) The progammer that uses the menu component should not be enforced to specify a parent menu when he wants to add a submenu.

namespace Ex04.Menus.Test
{
    internal static class DelegatesTest
    {
        public static void GetMenuDelegatesTest()
        {
            List<MenuChoice> choicesMain = new List<MenuChoice>();
            List<MenuChoice> versionAndSpacesMenuChoices = new List<MenuChoice>();
            List<MenuChoice> showDateAndTimeMenuChoices = new List<MenuChoice>();

            string headerMain = "----------Main delegates----------";
            string headerCustomer = "Version and Spaces";
            string headerManager = "Show Date/Time";

            Menu root = new Menu(headerMain, choicesMain, null);
            Menu versionAndSpacesMenu = new Menu(headerCustomer, versionAndSpacesMenuChoices, root);
            Menu showDateTimeMenu = new Menu(headerManager, showDateAndTimeMenuChoices, root);

            choicesMain.Add(new MenuChoice("Version and Spaces", versionAndSpacesMenu.Show));
            choicesMain.Add(new MenuChoice("Show Date/Time", showDateTimeMenu.Show));

            versionAndSpacesMenuChoices.Add(new MenuChoice("Count Spaces", TestFunctionsDelegates.CountSpaces));
            versionAndSpacesMenuChoices.Add(new MenuChoice("Show Version", TestFunctionsDelegates.ShowVersion));
            showDateAndTimeMenuChoices.Add(new MenuChoice("Show Time", TestFunctionsDelegates.ShowTime));
            showDateAndTimeMenuChoices.Add(new MenuChoice("Show Date", TestFunctionsDelegates.ShowDate));

            new MenuHandler(root).Show();
        }
    }
}