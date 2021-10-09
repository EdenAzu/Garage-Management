namespace Ex04.Menus.Delegates
{
    public class MenuHandler
    {
        private readonly Menu r_Root;

        public MenuHandler(Menu i_Root)
        {
            r_Root = i_Root;
        }

        public void Show()
        {
            r_Root.Show();
        }
    }
}