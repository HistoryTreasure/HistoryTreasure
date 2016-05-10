using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures
{
    class Map
    {
        Level _levels;
        Tile[,] _tileArray;

        public Map()
        {
            Tile[,] _tileArray = new Tile[288, 288];
        }

        public Level Level
        {
            get { return _levels; }
        }
    }
}
