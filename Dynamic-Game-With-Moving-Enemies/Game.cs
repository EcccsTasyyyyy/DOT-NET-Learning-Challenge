namespace Dynamic_Game_With_Moving_Enemies;

public class Game
{
    private readonly Player _player;
    private readonly Enemy[] _enemies;
    private readonly Treasure[] _treasures;
    private readonly Map _map;
    private readonly double safeDistance = 5;

    Random random = new();
    public Game()
    {

        int playerX = random.Next(Map.Height);
        int playerY = random.Next(Map.Width);

        _player = new(playerX, playerY);
        _enemies =
        [
            new (random.Next(Map.Height), random.Next(Map.Width)),
            new (random.Next(Map.Height), random.Next(Map.Width)),
            new (random.Next(Map.Height), random.Next(Map.Width))
        ];

        _treasures = new Treasure[]
        {
            new (random.Next(Map.Height), random.Next(Map.Width)),
            new (random.Next(Map.Height), random.Next(Map.Width))
        };

        _map = new Map(_player, _enemies, _treasures);
    }

    public bool IsPlayerSafe()
    {
        foreach (var enemy in _enemies)
        {
            if (_player.X == enemy.X && _player.Y == enemy.Y)
            {
                return false;
            }
        }
        return true;
    }

    private void TreasurePickup()
    {
        for (int i = 0; i < _treasures.Length; i++)
        {
            if (_player.X == _treasures[i].X && _player.Y == _treasures[i].Y)
            {
                _player.Score += 10;
                Console.WriteLine("Treasure picked up! Score increased!");

                SpawnNewTreasure(i);
            }
        }
    }

    public void SpawnNewTreasure(int i)
    {
        int newX, newY;

        bool isValidPosition;

        do
        {
            newX = random.Next(Map.Height);
            newY = random.Next(Map.Width);

            isValidPosition = true;

            if (_player.X == newX && _player.Y == newY)
                isValidPosition = false;

            foreach (var enemy in _enemies)
            {
                if (enemy.X == newX && enemy.Y == newY)
                {
                    isValidPosition = false;
                    break;
                }
            }

            foreach (var treasure in _treasures)
            {
                if (treasure.X == newX && treasure.Y == newY)
                {
                    isValidPosition = false;
                    break;
                }
            }
        } while (!isValidPosition);

        _treasures[i] = new Treasure(newX, newY);
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
        Console.WriteLine("Press Enter to start the game...");
        Console.ReadLine();

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

            TreasurePickup();
            DisplayPlayerProgress();

            Console.WriteLine("Enter movement directions (w/a/s/d) or (q) to quit: ");
            var userInput = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (userInput == 'q')
                break;

            _player.PlayerMovement(userInput);

            foreach (var enemy in _enemies)
                enemy.EnemyMovement();
        }
    }
}