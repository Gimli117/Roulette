using System.Runtime.Versioning;

namespace RussianRoulette
{
    [SupportedOSPlatform("Windows")]
    internal class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;               //Removes the flashing input bar in cmd window

            Console.SetCursorPosition(0, 0);             //Begins drawing the game in the top left corner
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Time for Russian Roulette!");
                Console.WriteLine("\nPlease select 1 for a quicker game, or select 2 for a longer game.\n\n");
                Console.WriteLine("1: One-Shot Roulette");
                Console.WriteLine("2: Extended Roulette");

                var choice = Console.ReadKey(true);

                switch (choice.Key)
                {
                    case ConsoleKey.D1:         //One-Shot
                        Console.Clear();

                        OneShot.ShortGame();
                        break;

                    case ConsoleKey.D2:         //Extended
                        Console.Clear();
                        Console.WriteLine("Does not exist yet.");
                        Thread.Sleep(3000);
                        //Fight.LongGame();
                        break;
                }
                Console.Clear();
            }
        }
    }
}
