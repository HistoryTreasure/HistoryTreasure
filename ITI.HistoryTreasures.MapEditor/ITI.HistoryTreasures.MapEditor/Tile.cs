using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures.MapEditor
{
    public class Tile
    {
        bool _isSolid;
        TileEnum _tileName;
        Map _mapContext;

        /// <summary>
        /// Tile Constructor create Tile.
        /// </summary>
        /// <param name="isSolid">This parameter define if a tile can be cross.</param>
        /// <param name="tileName">This parameter define the tileName.</param>
        /// <param name="mapContext">This parameter define the MapContext.</param>
        public Tile(bool isSolid, TileEnum tileName, Map mapContext)
        {
            _isSolid = isSolid;
            _tileName = tileName;
            _mapContext = mapContext;
        }
    }
}
