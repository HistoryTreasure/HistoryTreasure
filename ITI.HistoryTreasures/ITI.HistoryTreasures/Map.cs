using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures
{
    public class Map
    {
        Level _level;
        Tile[,] _tileArray;

        public Map(Level level/*, int width, int height*/)
        {
            _level = level;
            //_tileArray = new Tile[width, height];
        }

        public Level Level
        {
            get { return _level; }
        }

        public Tile[,] map1
        {
            get
            {
                Tile _floor = new Tile(false, TileEnum.BOATFLOOR, this);
                return _tileArray = new Tile[,] { { _floor, _floor }, { _floor, _floor } };
            }
        }

        public Tile[,] TileArray { get { return _tileArray; }  }
    }
}
