using System;

namespace Dynamic_Game_With_Moving_Enemies;

public class Enemy(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
    public static char Symbol => 'E';

    private static readonly Random random = new();

    //public void EnemyMovement(int playerX, int playerY)
    //{
    //    if (X < playerX) X++;
    //    else if (X > playerX) X--;

    //    if (Y < playerY) Y++;
    //    else if (Y > playerY) Y--;
    //}

    public void EnemyMovement()
    {
        int direction = random.Next(4); // 0 = Up, 1 = Down, 2 = Left, 3 = Right

        switch (direction)
        {
            case 0: if (X > 0) X--; break; // Move Up
            case 1: if (X < Map.Height - 1) X++; break; // Move Down
            case 2: if (Y > 0) Y--; break; // Move Left
            case 3: if (Y < Map.Width - 1) Y++; break; // Move Right
        }
    }
}