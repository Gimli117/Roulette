using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.Versioning;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RussianRoulette
{
    [SupportedOSPlatform("Windows")]
    internal class DrawArena
    {
        public static void DrawGrid()
        {
            for (int y = 0; y < Grid.arena.GetLength(1); y++)
            {
                for (int x = 0; x < Grid.arena.GetLength(0); x++)
                {
                    Console.CursorLeft = y;
                    Console.CursorTop = x;
                    if (Grid.arena[x, y] == 1)               // Left Player Head
                    {
                        Console.Write("☺");
                    }
                    else if (Grid.arena[x, y] == 2)          // Left Player Body
                    {
                        Console.Write("■");
                    }
                    else if (Grid.arena[x, y] == 3)          // Left Player Feet
                    {
                        Console.Write("A");
                    }
                    else if (Grid.arena[x, y] == 4)          // Right Player Head
                    {
                        Console.Write("☻");
                    }
                    else if (Grid.arena[x, y] == 5)          // Right Player Body
                    {
                        Console.Write("╦");
                    }
                    else if (Grid.arena[x, y] == 6)          // Right Player Feet
                    {
                        Console.Write("¶");
                    }
                    else if (Grid.arena[x, y] == 7)          //Left Player Gun
                    {
                        Console.Write("╔");
                    }
                    else if (Grid.arena[x, y] == 8)          //Right Player Gun
                    {
                        Console.Write("¬");
                    }
                }
            }
        }
        public static void DrawBullet(int whoseTurn)
        {
            if (whoseTurn == 1)         //Right Player
            {
                int bulletX = Grid.arena.GetLength(1) - 3;
                int bulletY = 1;

                DrawArena.DrawGrid();

                for (int i = 0; i < Grid.arena.GetLength(1) - 2; i++)
                {
                    Console.Clear();
                    DrawArena.DrawGrid();
                    Console.CursorLeft = bulletX;
                    Console.CursorTop = bulletY;
                    Console.Write("-");
                    bulletX--;
                    Thread.Sleep(25);
                }
            }
            else if (whoseTurn == 0)
            {                           //Left Player
                int bulletX = 2;
                int bulletY = 1;

                for (int i = 0; i < Grid.arena.GetLength(1) - 2; i++)
                {
                    Console.Clear();
                    DrawArena.DrawGrid();
                    Console.CursorLeft = bulletX;
                    Console.CursorTop = bulletY;
                    Console.Write("-");
                    bulletX++;
                    Thread.Sleep(25);
                }
            }
        }
    }
}
