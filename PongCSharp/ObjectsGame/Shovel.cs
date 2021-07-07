using System;
using static ConsoleManager.Console.ConsoleFunctions;
using static System.Console;

namespace PongCSharp.ObjectsGame
{
    public class Shovel : IShovel
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int SizeShovel { get; set; } = 4;
        public ConsoleKey KeyUp { get; set; }
        public ConsoleKey KeyDown { get; set; }
        public char CharacterShovel { get; set; } = 'ñ';

        public void ShowShovel()
        {
            for (int i = default; i < SizeShovel; i++)
            {
                GotoXY(PositionX, PositionY + i); Write(CharacterShovel);
            }
        }

        public void HideShovel()
        {
            for (int i = default; i < SizeShovel; i++)
            {
                GotoXY(PositionX, PositionY + i); Write("  "); Write("\r");
            }
        }

        public void Move(ConsoleKey key)
        {
            HideShovel();
            if (key == KeyUp)
            {
                PositionY--;
                ShowShovel();
            }
            if (key == KeyDown)
            {
                PositionY++;
                ShowShovel();
            }
            //if (key == ConsoleKey.LeftArrow)
            //{
            //    PositionX--;
            //    ShowShovel();
            //}
            //if (key== ConsoleKey.RightArrow)
            //{
            //    PositionX++;
            //    ShowShovel();
            //}
        }
    }
}
