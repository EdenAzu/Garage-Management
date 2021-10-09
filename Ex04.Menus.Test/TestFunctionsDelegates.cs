using System;

namespace Ex04.Menus.Test
{
    internal static class TestFunctionsDelegates
    {
        internal static void ShowVersion()
        {
            Console.WriteLine("Version: 21.3.4.8930");
            Console.WriteLine("press a key to continue.");
            Console.ReadKey();
        }

        internal static void CountSpaces()
        {
            string inputFromUser;
            int count = 0;
            
            Console.WriteLine("Please Write a sentence");
            inputFromUser = Console.ReadLine();
            foreach(char letter in inputFromUser)
            {
                if(letter == ' ')
                {
                    count++;
                }
            }

            Console.WriteLine($"Number of spaces: {count}");
            Console.WriteLine("press a key to continue.");
            Console.ReadKey();
        }

        internal static void ShowTime()
        {
            Console.WriteLine($"{DateTime.Now.TimeOfDay}");
            Console.WriteLine("press a key to continue.");
            Console.ReadKey();
        }

        internal static void ShowDate()
        {
            Console.WriteLine($"{DateTime.Now.Date}");
            Console.WriteLine("press a key to continue.");
            Console.ReadKey();
        }
    }
}