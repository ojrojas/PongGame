using System;
using System.Drawing;
using static System.Console;


namespace ConsoleManager.Console
{
    public static class ConsoleFunctions
    {
        public static void GotoXY(int x, int y)
        {
            SetCursorPosition(x, y);
        }

        public static void PrintCodeAscci()
        {
            for (int i = 0; i < 256; i++)
            {
                WriteLine("{0} = {1} ", i, (char)i);
            }
        }

        public static void CreateScreen(int width,
                                        int height,
                                        char characterScreen,
                                        char characterCorner,
                                        ConsoleColor color)
        {

            ForegroundColor = color;

            // lienas horizontales
            for (int i = 1; i < width; i++)
            {
                GotoXY(i, 4); Write(characterScreen);
                GotoXY(i, height - 1); Write(characterScreen);
            }

            //lineas verticales
            for (int v = 4; v < height; v++)
            {
                GotoXY(1, v); Write(characterScreen);
                GotoXY(width - 1, v); Write(characterScreen);
            }

            //esquinas

            GotoXY(1, 4); Write('1');
            GotoXY(1, width - 1); Write('2');
            GotoXY(1, height - 1); Write('3');
            GotoXY(width - 1, height - 1); Write('4');

            GotoXY(2, 2);
            HideCursor();
        }

        public static void HideCursor()
        {
            CursorVisible = false;
        }
    }
}
