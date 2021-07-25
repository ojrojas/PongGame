using System;
using static System.Console;


namespace ConsoleManager.Console
{
    public static class ConsoleFunctions
    {
        /// <summary>
        /// Ir a x y posicion de pantalla
        /// </summary>
        /// <param name="x">coordenadas x</param>
        /// <param name="y">coordenadas y</param>
        public static void GotoXY(int x, int y)
        {
            SetCursorPosition(x, y);
            HideCursor();
        }

        /// <summary>
        /// Imprimir codio asscii
        /// </summary>
        public static void PrintCodeAscci()
        {
            for (int i = 0; i < 256; i++)
            {
                WriteLine("{0} = {1} ", i, (char)i);
            }
        }

        /// <summary>
        /// Crear pantalla de juego
        /// </summary>
        /// <param name="width">Ancho</param>
        /// <param name="height">Alto</param>
        /// <param name="characterScreen">Caracteres de pantalla</param>
        /// <param name="characterCorner">Caracteres de esquinas</param>
        /// <param name="color">Color de la pantalla</param>
        public static void CreateScreen(int width,
                                        int height,
                                        char characterScreen,
                                        char characterCorner,
                                        ConsoleColor color = ConsoleColor.White, 
                                        ConsoleColor colorFondo = ConsoleColor.Black)
        {
            // color de la pantalla
            ForegroundColor = color;
            BackgroundColor = colorFondo;
            
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

            // position al terminar de crear la pantalla
            GotoXY(2, 2);
            
            HideCursor();
        }

        /// <summary>
        /// Oculta el cursor en la pantalla
        /// </summary>
        public static void HideCursor()
        {
            CursorVisible = false;
        }
    }
}
