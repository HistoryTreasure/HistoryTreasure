using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures
{
    class Tile
    {
        bool _isSolid;
        TileEnum _tileName;
        Map _mapContext;

        /// <summary>
        /// Tile Constructor
        /// </summary>
        /// <param name="isSolid"></param>
        /// <param name="tileName"></param>
        /// <param name="mapContext"></param>
        public Tile(bool isSolid, TileEnum tileName, Map mapContext)
        {
            _isSolid = isSolid;
            _tileName = tileName;
            _mapContext = mapContext;
        }


        /// <summary>
        /// Map Context
        /// </summary>
        internal Map Map
        {
            get
            {
                return _mapContext;
            }
        }

        /// <summary>
        /// References Tile's name
        /// </summary>
        public TileEnum TileEnum
        {
            get
            {
                return _tileName;
            }
        }

        /// <summary>
        /// Define if the is tile Solid
        /// </summary>
        public bool IsSolid
        {
            get { return _isSolid; }
        }
    }
}
