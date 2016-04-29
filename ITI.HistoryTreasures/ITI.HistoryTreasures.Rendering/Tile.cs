using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ITI.HistoryTreasures
{
    class Tile : Resources
    {
        bool _isSolid;
        Image _sprite; //reference to an image

        public Tile(bool IsSolid, Image Sprite)
        {
            if (Sprite == null) throw new ArgumentNullException();
            _isSolid = IsSolid;
            _sprite = Sprite;
        }

        public bool IsSolid
        {
            get { return _isSolid; }
        }

        public Image Sprite
        {
            get { return _sprite; }
        }

        public Map MapDesign
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