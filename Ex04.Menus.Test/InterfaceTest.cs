using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal static class InterfaceTest
    {
        public static void GetMenuInterfaceTest()
        {
            MenuItem spaces = new MenuItem("Count Spaces");
            MenuItem version = new MenuItem("Show Version");
            MenuItem showDate = new MenuItem("Show Date");
            MenuItem showTime = new MenuItem("Show Time");

            spaces.SelectionListeners.Add(new CountSpaces());
            version.SelectionListeners.Add(new ShowVersion());
            showDate.SelectionListeners.Add(new ShowDate());
            showTime.SelectionListeners.Add(new ShowTime());

            // $G$ SFN-004 (-7) The menu items containing the exit / back option should be created by the menu itself, not by the user.
            MainMenu menuInterface = new MainMenu("----------Main interface----------", "Exit");
            MainMenu versionAndSpacesSubMenu = new MainMenu("Version and Spaces", "Back");
            MainMenu showDateAndTimeSubMenu = new MainMenu("Show Date/Time", "Back");

            menuInterface.MenuItemsList.Add(versionAndSpacesSubMenu);
            menuInterface.MenuItemsList.Add(showDateAndTimeSubMenu);

            versionAndSpacesSubMenu.MenuItemsList.Add(spaces);
            versionAndSpacesSubMenu.MenuItemsList.Add(version);
            showDateAndTimeSubMenu.MenuItemsList.Add(showDate);
            showDateAndTimeSubMenu.MenuItemsList.Add(showTime);

            menuInterface.Show();
        }
    }
}