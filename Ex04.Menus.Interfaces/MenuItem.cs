using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        public MenuItem(string i_Title)
        {
            Title = i_Title;
        }

        public int Level { get; set; }

        public string Title { get; }

        public List<IMenuSelection> SelectionListeners { get; } = new List<IMenuSelection>();

        public MainMenu ParentMenu { get; set; }

        public override string ToString()
        {
            StringBuilder menuDescription = new StringBuilder();
            menuDescription.AppendLine(string.Format("{0}:", Title));
            menuDescription.AppendFormat("The level now is: {0}", Level);

            return menuDescription.ToString();
        }
    }
}