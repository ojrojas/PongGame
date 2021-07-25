using PongCSharp.ObjectsGame;
using System;
using static ConsoleManager.Console.ConsoleFunctions;


namespace PongCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            (int x, int y) = (70, 30);

            bool gameOver = false;
            IShovel shovel2 = new Shovel { PositionX = 3, PositionY = 16, KeyUp = ConsoleKey.UpArrow, KeyDown = ConsoleKey.DownArrow };
            IShovel shovel1 = new Shovel { PositionX = x - 3, PositionY = 16, KeyUp = ConsoleKey.O, KeyDown = ConsoleKey.L };
            IShovel shovel3 = new Shovel { PositionX = 15 , PositionY = 16, KeyUp = ConsoleKey.E, KeyDown = ConsoleKey.D };

            CreateScreen(x, y, '@', '0', ConsoleColor.Yellow);
          

            while (!gameOver)
            {
                shovel1.ShowShovel();
                shovel2.ShowShovel();

                if (!Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    shovel1.Move(key.Key);
                    shovel2.Move(key.Key);
                    shovel3.Move(key.Key);  
                  
                }
                
            }
        }
    }
}
