namespace Dynamic_Game_With_Moving_Enemies;

public class Game
{
    private Player _player;
    private Enemy[] _enemies;
    private Treasure _treasure;
    private Map _map;
    private double safeDistance = 5;

    public Game()
    {
        _player = new Player(20, 30);
        _enemies = new Enemy[]
        {
            new Enemy(2,4),
            new Enemy(10,6),
            new Enemy(25,20)
        };

        _treasure = new Treasure(15, 22);

        _map = new Map(_player, _enemies, _treasure);
    }

    public bool IsPlayerSafe()
    {
        foreach (var enemy in _enemies)
        {
            int dx = _player.X - enemy.X;
            int dy = _player.Y - enemy.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            if (distance <= safeDistance)
            {
                return false;
            }
        }
        return true;
    }

    public void DisplayPlayerProgress()
    {
        Console.Write($"Player Score: {_player.Score}");

        for (int i = 0; i < _player.Score / 5; i++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
    }

    public void Play()
    {
        foreach (var enemy in _enemies)
        {
            enemy.EnemyMovement();
        }

        while (true)
        {
            _map.DisplayMap();

            if (IsPlayerSafe())
            {
                _player.Score += 5;
                Console.WriteLine("Player is safe! Score increased.");
            }
            else
            {
                Console.WriteLine("Game Over! Player caught by enemy.");
                break;
            }

            DisplayPlayerProgress();

            Console.WriteLine("Press Enter to continue or 'q' to quit.");

            if (Console.ReadLine().ToLower() == "q")
                break;

            _player.PlayerMovement();

            foreach (var enemy in _enemies)
            {
                enemy.EnemyMovement();
            }
        }
    }
}