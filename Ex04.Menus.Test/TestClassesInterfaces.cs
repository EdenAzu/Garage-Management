using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowTime : IMenuSelection
    {
        void IMenuSelection.NotifyListener()
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            Console.WriteLine("Press any key to go back. ");
            Console.ReadKey();
        }
    }


    public class ShowDate : IMenuSelection
    {
        void IMenuSelection.NotifyListener()
        {
            Console.Clear();
            Console.WriteLine(DateTime.Now.ToShortDateString());
            Console.WriteLine("Press any key to go back. ");
            Console.ReadKey();
        }
    }

    public class ShowVersion : IMenuSelection
    {
        void IMenuSelection.NotifyListener()
        {
            Console.Clear();
            Console.WriteLine("Version: 21.1.4.8930");
            Console.WriteLine("Press any key to go back. ");
            Console.ReadKey();
        }
    }

    public class CountSpaces : IMenuSelection
    {
        void IMenuSelection.NotifyListener()
        {
            Console.Clear();
            Console.WriteLine("Please enter a string. ");
            string inputString = Console.ReadLine();
            int countSpaces = 0;

            if(inputString != null)
            {
                foreach(char c in inputString)
                {
                    if(c == ' ')
                    {
                        countSpaces++;
                    }
                }
            }

            Console.WriteLine("This sentence has {0} spaces", countSpaces);
            Console.WriteLine("Press any key to go back. ");
            Console.ReadKey();
        }
    }
}