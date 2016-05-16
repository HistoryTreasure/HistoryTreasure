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

        /// <summary>
        /// This constructor create a Map.
        /// </summary>
        /// <param name="level">Level context.</param>
        public Map(Level level/*, int width, int height*/)
        {
            _level = level;
            //_tileArray = new Tile[width, height];
        }

        /// <summary>
        /// This propertie return a level.
        /// </summary>
        public Level Level
        {
            get { return _level; }
        }

        /// <summary>
        /// This propertie return tile array (2D).
        /// </summary>
        public Tile[,] map1
        {
            get
            {
                Tile _floor = new Tile(false, TileEnum.BOATFLOOR, this);
                return _tileArray = new Tile[,] { { _floor, _floor }, { _floor, _floor } };
            }
        }

        /// <summary>
        /// This propertie return field tilearray.
        /// </summary>
        public Tile[,] TileArray { get { return _tileArray; }  }
    }
}
