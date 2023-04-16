using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    class Move
    {
        public Player Player { get; private set; }
        public int Row { get; private set; }
        public int Col { get; private set; }

        public Move(Player player, int row, int col)
        {
            Player = player;
            Row = row;
            Col = col;
        }
    }
}
