using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        int _posX;
        int _posY;

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

        public void CreateTileHitbox(int x, int y)
        {
            //_hitbox = new Hitbox(x,y,Map.Width / );
        }

        /// <summary>
        /// Return map context. 
        /// </summary>
        public Map Map
        {
            get { return _mapContext; }
        }

        /// <summary>
        /// Return Tile's name.
        /// </summary>
        public TileEnum TileType
        {
            get { return _tileName; }
        }

        public Hitbox TileHitbox
        {
            get { return _hitbox; }
        }

        public int posX
        {
            get { return _posX; }
            set { _posX = value; }
        }
        public int posY
        {
            get { return _posY; }
            set { _posY = value; }
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
