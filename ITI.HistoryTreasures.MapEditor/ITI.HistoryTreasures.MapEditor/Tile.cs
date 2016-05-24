using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures.MapEditor.Core
{
    public class Tile
    {
        bool _isSolid;
        TileEnum _tileName;

        /// <summary>
        /// Tile Constructor create Tile.
        /// </summary>
        /// <param name="isSolid">This parameter define if a tile can be cross.</param>
        /// <param name="tileName">This parameter define the tileName.</param>
        public Tile(bool isSolid, TileEnum tileName)
        {
            _isSolid = isSolid;
            _tileName = tileName;
        }


    }
}
