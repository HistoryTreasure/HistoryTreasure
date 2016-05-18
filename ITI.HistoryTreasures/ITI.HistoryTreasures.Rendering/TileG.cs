using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ITI.HistoryTreasures
{
    class TileG : Resource
    {
        Image _sprite; //reference to an image
        TileEnum _tileName;

        /// <summary>
        /// This contructor create TileG.
        /// </summary>
        /// <param name="Sprite">This parameter define the sprite name.</param>
        /// <param name="tileName">This parameter define the tileName.</param>
        public TileG(Image Sprite, TileEnum tileName)
        {
            if (Sprite == null) throw new ArgumentNullException();
            _sprite = Sprite;
            _tileName = tileName;
        }

        /// <summary>
        /// Return tile image.
        /// </summary>
        public Image Sprite
        {
            get { return _sprite; }
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