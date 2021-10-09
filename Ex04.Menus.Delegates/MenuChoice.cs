using System;

// $G$ DSN-006 (-5) Bad using of Delegates.

namespace Ex04.Menus.Delegates
{
    public class MenuChoice
    {
        public MenuChoice(string i_Title, Action i_Action)
        {
            Title = i_Title;
            Action = i_Action;
        }

        public string Title { get; }

        public Action Action { get; }
    }
}