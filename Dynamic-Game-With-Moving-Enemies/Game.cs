namespace Dynamic_Game_With_Moving_Enemies;

public class Game
{
    private readonly Player _player;
    private readonly Enemy[] _enemies;
    private readonly Treasure[] _treasures;
    private readonly Map _map;
    private readonly double safeDistance = 5;

    public Game()
    {
        Random random = new Random();

        int playerX = random.Next(Map.Height);
        int playerY = random.Next(Map.Width);

        _player = new(playerX,playerY);
        _enemies =
        [
            new (random.Next(Map.Height), random.Next(Map.Width)),
            new (random.Next(Map.Height), random.Next(Map.Width)),
            new (random.Next(Map.Height), random.Next(Map.Width))
        ];

        _treasures =
        [
            new (random.Next(Map.Height), random.Next(Map.Width)),
            new (random.Next(Map.Height), random.Next(Map.Width))
        ];

        _map = new Map(_player, _enemies, _treasures);
    }

    public bool IsPlayerSafe()
    {
        foreach (var enemy in _enemies)
        {
            if(_player.X == enemy.X && _player.Y == enemy.Y)
            {
                return false;
            }
        }
        return true;
    }

    public void DisplayPlayerProgress()
    {
        Console.Write($"Player Score: {_player.Score}");

        for (int i = 0; i < _player.Score / 2; i++)
        {
            Console.Write("*");
        }
        Console.Write($"\nPlayer Health: {_player.Health}");
        Console.WriteLine();
    }

    public void Play()
    {
        while (true)
        {
            _map.DisplayMap();

            if (IsPlayerSafe())
            {
                Console.WriteLine("Player is safe! score increased");
                _player.Score += 5;
            }
            else
            {
                Console.WriteLine("Game Over!, Player caught by enemy");
                break;
            }

            DisplayPlayerProgress();

            Console.WriteLine("Press Enter to continue or 'q' to quit.");
            var input = Console.ReadLine();

            if (input != null && input.ToLower() == "q")
                break;

            Console.WriteLine("Enter movement direction (w/a/s/d): ");
            var direction = Console.ReadKey().KeyChar;
            Console.WriteLine();

            _player.PlayerMovement(direction);

            foreach (var enemy in _enemies)
                enemy.EnemyMovement();
        }
    }
}