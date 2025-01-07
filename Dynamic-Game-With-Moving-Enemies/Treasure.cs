using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_Game_With_Moving_Enemies
{
    public class Treasure
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char symbol = 'T';

        public Treasure(int x, int y)
        {
            X = x;
            Y = y;
        }

        private static readonly Random random = new Random();

        public void TreasureMovement()
        {
            int dx = random.Next(1, 50);
            int dy = random.Next(1, 50);
        }
    }
}
