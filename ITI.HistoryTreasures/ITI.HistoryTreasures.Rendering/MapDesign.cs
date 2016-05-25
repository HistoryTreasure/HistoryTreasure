using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ITI.HistoryTreasures
{
    class MapDesign
    {
        Game _ctx;
        Bitmap _bitmap;
        private int _x;
        private int _y;

        /// <summary>
        /// This constructor instantiate a new MapDesign.
        /// </summary>
        /// <param name="ctx">This parameter contains Game context.</param>
        /// <param name="_resource">This parameter contains a bitmap.</param>
        public MapDesign(Game ctx, Bitmap resource)
        {
            _ctx = ctx;
            _bitmap = new Bitmap(resource);
        }

        /// <summary>
        /// This property returns coordonate X.
        /// </summary>
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        /// This property returns coordonate Y.
        /// </summary>
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// This method draw a image.
        /// </summary>
        /// <param name="gfx">This parameter contains graphics.</param>
        public void DrawImage(Graphics gfx)
        {
            gfx.DrawImage(_bitmap, X, Y);
        }
    }
}