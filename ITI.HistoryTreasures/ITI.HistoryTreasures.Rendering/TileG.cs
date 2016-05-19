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
        /// This contructor create TileG.
        /// </summary>
        /// <param name="Sprite">This parameter define the sprite name.</param>
        /// <param name="tileName">This parameter define the tileName.</param>
        public TileG(Bitmap tileG, TileEnum tileName)
        {
            if (TileGr == null) throw new ArgumentNullException();
            _tileG = tileG;
            _tileName = tileName;
        }

        /// <summary>
        /// Return tile image.
        /// </summary>
        public Bitmap TileGr
        {
            get { return _tileG; }
        }

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