using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ITI.HistoryTreasures.Rendering
{
    class ResourcesManager
    {
        Dictionary<TileEnum, Bitmap> _tileBitmaps;

        public ResourcesManager()
        {
            _tileBitmaps = new Dictionary<TileEnum, Bitmap>();
            _tileBitmaps[TileEnum.GRASS] = Properties.Resources.herbe;
            _tileBitmaps[TileEnum.WATER] = Properties.Resources.eau;
        }

        public Bitmap GetTileBitmap(Tile tile)
        {
            return _tileBitmaps[tile.TileType];
        }
    }
}
