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

        public Tile(bool isSolid, TileEnum tileName, Map mapContext)
        {
            _isSolid = isSolid;
            _tileName = tileName;
            _mapContext = mapContext;
        }

        internal Map Map
        {
            get
            {
                return _mapContext;
            }
        }

        public TileEnum TileEnum
        {
            get
            {
                return _tileName;
            }
        }

        public bool IsSolid
        {
            get { return _isSolid; }
        }
    }
}
