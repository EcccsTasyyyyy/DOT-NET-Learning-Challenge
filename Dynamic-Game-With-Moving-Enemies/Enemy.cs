namespace Dynamic_Game_With_Moving_Enemies;

public class Enemy
{
    public int X { get; set; }
    public int Y { get; set; }
    public char symbol = 'E';

    public Enemy(int x, int y)
    {
        X = x;
        Y = y;
    }

    private static readonly Random random = new Random();

    public void EnemyMovement()
    {
        int dx = random.Next(1, 50);
        int dy = random.Next(1, 50);

        X = dx;
        Y = dy;
    }
}