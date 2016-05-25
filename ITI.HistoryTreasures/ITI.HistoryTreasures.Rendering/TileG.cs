using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ITI.HistoryTreasures
{
    class TileG : Resource
    {
        Bitmap _tileG; //reference to an image
        TileEnum _tileName;

        /// <summary>
        /// This contructor instantiate TileG.
        /// </summary>
        /// <param name="tileG">This parameter contains the tile bitmap.</param>
        /// <param name="tileName">This parameter contains the tileName.</param>
        public TileG(Bitmap tileG, TileEnum tileName)
        {
            if (TileGr == null) throw new ArgumentNullException();
            _tileG = tileG;
            _tileName = tileName;
        }

        /// <summary>
        /// This property returns a tile.
        /// </summary>
        public Bitmap TileGr
        {
            get { return _tileG; }
        }

        /// <summary>
        /// This property returns MapDesign context.
        /// </summary>
        public MapDesign MapDesign
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}