using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures
{
    public class Tile
    {
        bool _isSolid;
        TileEnum _tileName;
        Map _mapContext;
        Hitbox _hitbox;
        readonly int _posX;
        readonly int _posY;

        public Tile(bool isSolid, TileEnum tileName, Map mapContext, int posX, int posY)
        {
            _isSolid = isSolid;
            _tileName = tileName;
            _mapContext = mapContext;
            _posX = posX;
            _posY = posY;
            _hitbox = new Hitbox(posX - 16, posY + 16, posX + 16, posY - 16);
        }

        internal Map Map
        {
            get
            { return _mapContext; }
        }

        public TileEnum TileEnum
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

        public bool IsSolid
        {
            get { return _isSolid; }
        }
    }
}
