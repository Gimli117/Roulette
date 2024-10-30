using System;
using System.Media;
using System.Runtime.Versioning;

namespace RussianRoulette
{
    [SupportedOSPlatform("Windows")]
    internal class OneShot
    {
        public static void ClearInputBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }

        public static void ShortGame()
        {
            SoundPlayer shot = new SoundPlayer();
            shot.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "shot.wav";

            SoundPlayer miss = new SoundPlayer();
            miss.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "miss.wav";

            SoundPlayer dead = new SoundPlayer();
            dead.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "dead.wav";

            SoundPlayer musicBG = new SoundPlayer();
            musicBG.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "BG.wav";

            Random zeroOrOne = new Random();
            Random turnNum = new Random();
            int playerHealthLeft = 1;
            int playerHealthRight = 1;
            bool death = false;

            int whoseTurn = turnNum.Next(0, 2);

            while (!death)
            {
                musicBG.Play();

                int shotDmg = zeroOrOne.Next(0, 10);

                if (whoseTurn == 0)
                {
                    DrawArena.DrawGrid();
                    Console.WriteLine("\n\n↑");
                    Console.WriteLine("\n\nLeft Player! Press Enter to try your luck...");
                }
                else if (whoseTurn == 1)
                {
                    DrawArena.DrawGrid();
                    Console.WriteLine("\n\n\t      ↑");
                    Console.WriteLine("\n\nRight Player! Press Enter to try your luck...");
                }
                ClearInputBuffer();
                Console.ReadKey();

                switch (whoseTurn)
                {
                    case 0:                     //Left Player
                        if (shotDmg > 4)
                        {
                            shot.Play();

                            playerHealthRight = playerHealthRight - shotDmg;

                            Console.Clear();
                            DrawArena.DrawBullet(whoseTurn);
                        }
                        else
                        {
                            miss.Play();

                            Console.WriteLine("\n\nToo bad! Right player's turn -->");
                            Thread.Sleep(2000);
                            whoseTurn = 1;
                        }
                        break;

                    case 1:                     //Right Player
                        if (shotDmg > 4)
                        {
                            shot.Play();

                            playerHealthLeft = playerHealthLeft - shotDmg;

                            Console.Clear();
                            DrawArena.DrawBullet(whoseTurn);
                        }
                        else
                        {
                            miss.Play();

                            Console.WriteLine("\n\nToo bad! Left player's turn <--");
                            Thread.Sleep(2000);
                            whoseTurn = 0;
                        }
                        break;
                }
                Console.Clear();
                if (playerHealthLeft <= 0)
                {
                    dead.Play();

                    death = true;

                    Console.WriteLine("Right Player won!");
                    Thread.Sleep(3000);
                }
                else if (playerHealthRight <= 0)
                {
                    dead.Play();

                    death = true;

                    Console.WriteLine("Left Player won!");
                    Thread.Sleep(3000);
                }
            }
        }
    }
}
