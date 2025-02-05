using System;

namespace Pong.ObjectsGame;
    public interface IShovel
    {
        char CharacterShovel { get; set; }
        ConsoleKey KeyDown { get; set; }
        ConsoleKey KeyUp { get; set; }
        int PositionX { get; set; }
        int PositionY { get; set; }
        int SizeShovel { get; set; }

        void HideShovel();
        void Move(ConsoleKey key);
        void ShowShovel();
    }