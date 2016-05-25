using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures
{
    public class Map
    {
        readonly Level _level;
        Tile[,] _tileArray;

        /// <summary>
        /// This constructor create a Map.
        /// </summary>
        /// <param name="level">Level context.</param>
        public Map(Level level, int width, int height)
        {
            _level = level;
            TileArray = _tileArray;
            _tileArray = new Tile[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    _tileArray[i, j] = new Tile(false, TileEnum.GRASS, level.MapContext);
                } 
            }
        }

        /// <summary>
        /// This property returns a level.
        /// </summary>
        public Level Level
        {
            get { return _level; }
        }

        /// <summary>
        /// This property returns tile array (2D).
        /// </summary>
        /*public Tile[,] map1
        {
            get
            {
                Tile _floor = new Tile(false, TileEnum.BOATFLOOR, this);
                return _tileArray = new Tile[,] { { _floor, _floor }, { _floor, _floor } };
            }
        }*/

        /// <summary>
        /// This property returns field tilearray.
        /// </summary>
        public Tile[,] TileArray
        {
            get { return _tileArray; }
            set { _tileArray = value; }
        }

        /// <summary>
        /// This property returns vertical length of array.
        /// </summary>
        public int Height
        {
            get { return _tileArray.GetLength(1);  }
        }

        /// <summary>
        /// This property returns horizontal length of array.
        /// </summary>
        public int Width
        {
            get { return _tileArray.GetLength(0); }
        }
    }
}
