using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    class Player
    {
        public string Name { get; private set; }
        public CellState Symbol { get; private set; }

        public Player(string name, CellState symbol)
        {
            Name = name;
            Symbol = symbol;
        }
    }

    enum CellState
    {
        Empty,
        X,
        O
    }
}
