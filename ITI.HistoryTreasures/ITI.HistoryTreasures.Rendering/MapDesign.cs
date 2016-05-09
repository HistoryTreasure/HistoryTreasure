using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ITI.HistoryTreasures
{
    class MapDesign : Control
    {
        //byte[][] _data;
        //Dictionary<byte,TileG> _tiles;
        Game _context;

        public MapDesign(Game g)
        {
            _context = g;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var bmp = new Bitmap(Rendering.Properties.Resources.eau);

            e.Graphics.DrawImage(bmp, 0,0);
        }
    }
}