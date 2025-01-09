namespace Dynamic_Game_With_Moving_Enemies;

public class Player(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
    public int Score { get; set; } = 0;
    public int Health { get; set; } = 100;
    public static char Symbol => 'P';

    public void PlayerMovement(char direction)
    {
        switch (direction)
        {
            case 'w': if (X > 0) X--; break; //Move up
            case 's': if (X < Map.Height - 1) X++; break; //Move down
            case 'a': if (Y > 0) Y--; break; //Move left
            case 'd': if (Y < Map.Width - 1) Y++; break; //Move right
        }
    }

    public void CollectTreasure()
    {
        Score += 10;
    }

    public void DecreaseHealth()
    {
        Health -= 10;
    }
}