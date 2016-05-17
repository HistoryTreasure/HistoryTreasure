#define My_Debug

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ITI.HistoryTreasures
{
    class MapDesign : IDisposable
    {
        bool disposed = false;
        //byte[][] _data;
        //Dictionary<byte,TileG> _tiles;
        Game _context;
        Bitmap _bitmap;
        MapDesign _mouse;

        private int X;
        private int Y;

        public int left { get { return X; } set { X = value; } }
        public new int Top { get { return Y; } set { Y = value; } }

        public MapDesign(Game g, Bitmap _resouce)
        {
            _context = g;
            _bitmap = new Bitmap(_resouce);
        }


        public void drawImage(Graphics gfx)
        {
            gfx.DrawImage(_bitmap, X, Y);

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                _bitmap.Dispose();
            }
            disposed = true;
        }
    }
}

            ////using (Pen p = new Pen(Brushes.DeepSkyBlue))
            //{
            //    var bmp = new Bitmap(Rendering.Properties.Resources.eau);

            //    e.Graphics.DrawImage(bmp , 0, 0, Width - 1, Height - 1);
            //    dra
            //}
            ////   base.OnPaint(e);

       
