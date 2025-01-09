namespace Dynamic_Game_With_Moving_Enemies;

public class Map(Player player, Enemy[] enemies, Treasure[] treasures)
{
    public const int Width = 30;
    public const int Height = 20;
    public readonly char[,] _map = new char[Height, Width];

    private readonly Player _player = player;
    private readonly Enemy[] _enemies = enemies;
    private readonly Treasure[] _treasures = treasures;

    private void ClearMap()
    {
        for (int i = 0; i < Height; i++)
            for (int j = 0; j < Width; j++)
                _map[i, j] = '.';
    }

    private void PlaceObjects()
    {
        if (_player.X >= 0 && _player.X < Height && _player.Y >= 0 && _player.Y < Width)
            _map[_player.X, _player.Y] = Player.Symbol;

        foreach (var enemy in _enemies)
            if (enemy.X >= 0 && enemy.X < Height && enemy.Y >= 0 && enemy.Y < Width)
                _map[enemy.X, enemy.Y] = Enemy.Symbol;

        foreach (var treasure in _treasures)
            if (treasure.X >= 0 && treasure.X < Height && treasure.Y >= 0 && treasure.Y < Width)
                _map[treasure.X, treasure.Y] = Treasure.Symbol;
    }

    public void DisplayMap()
    {
        ClearMap();
        PlaceObjects();

        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                Console.Write(_map[i, j]);
            }
            Console.WriteLine();
        }
    }
}