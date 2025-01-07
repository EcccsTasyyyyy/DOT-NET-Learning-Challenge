namespace Dynamic_Game_With_Moving_Enemies;

public class Map
{
    private readonly Player _player;
    private readonly Enemy[] _enemies;
    private readonly Treasure _treasure;
    public const int width = 50;
    public const int height = 50;
    public const char emptySpace = '.';
    public char[,] map = new char[width, height];

    public Map(Player player, Enemy[] enemies, Treasure treasure)
    {
        _player = player;
        _enemies = enemies;
        _treasure = treasure;
    }

    public void InitializeMap()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                map[i, j] = emptySpace;
            }
        }
    }

    public void PlacePlayer()
    {
        map[_player.X, _player.Y] = _player.symbol;
    }

    public void PlaceEnemy()
    {
        foreach (var enemy in _enemies)
        {
            map[enemy.X, enemy.Y] = enemy.symbol;
        }
    }

    public void PlaceTreasure()
    {
        map[_treasure.X, _treasure.Y] = _treasure.symbol;
    }

    public void DisplayMap()
    {
        InitializeMap();

        //PlacePlayer();

        //PlaceEnemy();

        //PlaceTreasure();

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Console.Write(map[i, j]);
            }
            Console.WriteLine();
        }
    }
}