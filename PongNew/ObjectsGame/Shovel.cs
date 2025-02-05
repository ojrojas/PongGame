
namespace Pong.ObjectsGame;
public class Shovel : IShovel
{
    public int PositionX { get; set; }
    public int PositionY { get; set; }
    public int SizeShovel { get; set; } = 4;
    public ConsoleKey KeyUp { get; set; }
    public ConsoleKey KeyDown { get; set; }
    public char CharacterShovel { get; set; } = 'ñ';
    private char CharacterHideShovel { get; set; } = ' ';

    public void ShowShovel()
    {
        for (int i = default; i < SizeShovel; i++)
        {
//            GotoXY(PositionX, PositionY + i); Write(CharacterShovel);
        }
    }

    public void HideShovel()
    {
        for (int i = default; i < SizeShovel; i++)
        {
         //  GotoXY(PositionX, PositionY + i); Write(CharacterHideShovel);
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
    }
}