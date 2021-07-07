using System;

namespace PongCSharp.ObjectsGame
{
    public interface IShovel
    {
        int PositionX { get; set; }
        int PositionY { get; set; }
        int SizeShovel { get; set; }

        void HideShovel();
        void Move(ConsoleKey key);
        void ShowShovel();
    }
}