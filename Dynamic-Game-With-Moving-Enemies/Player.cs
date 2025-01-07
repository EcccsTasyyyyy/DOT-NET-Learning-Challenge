namespace Dynamic_Game_With_Moving_Enemies;

public class Player
{
    public int X {  get; set; }
    public int Y { get; set; }
    public int Score { get; set; }
    public char symbol = 'P';
    public Player(int x, int y)
    {
        X = x;
        Y = y;
        Score = 0;
    }

    private static readonly Random random = new Random();

    public void PlayerMovement()
    {
        int dx = random.Next(1, 50);
        int dy = random.Next(1, 50);

        X = dx;
        Y = dy;
    }
}