using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures
{
    class Map
    {
        Level _level;
        Tile[,] _tileArray;

        public Map(Level level, int width, int height)
        {
            _level = level;
            _tileArray = new Tile[width, height];
        }

        public Level Level
        {
            get { return _level; }
        }
    }
}
