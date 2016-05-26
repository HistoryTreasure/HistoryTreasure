using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures
{
    public class Tile
    {
        readonly bool _isSolid;
        readonly TileEnum _tileName;
        readonly Map _mapContext;
        Hitbox _hitbox;
        readonly int _posX;
        readonly int _posY;

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

            if (isSolid == true)
            {
                _hitbox = new Hitbox(posX - 16, posY + 16, posX + 16, posY - 16);
            }
        }

        public void CreateTileHitbox(Tile[,] tilearray)
        {
            foreach (Tile tile in tilearray)
            {
                if (tile.IsSolid == true)
                {
                    
                }
            }
        }

        /// <summary>
        /// Return map context. 
        /// </summary>
        public Map Map
        {
            get
            { return _mapContext; }
        }

        /// <summary>
        /// Return Tile's name.
        /// </summary>
        public TileEnum TileType
        {
            get { return _tileName;}
        }

        public Hitbox TileHitbox
        {
            get { return _hitbox; }
        }

        public int posX
        {
            get { return _posX; }
        }
        public int posY
        {
            get { return _posY; }
        }

        /// <summary>
        /// Return if tile is solid.
        /// </summary>
        public bool IsSolid
        {
            get { return _isSolid; }
        }
    }
}
