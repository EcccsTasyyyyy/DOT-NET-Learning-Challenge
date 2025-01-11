namespace Dynamic_Game_With_Moving_Enemies
{
    public class Treasure(int x, int y)
    {
        public int X { get; set; } = x;
        public int Y { get; set; } = y;
        public static char Symbol => 'T';
    }
}