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


    class MapDesign
    {
        bool disposed = false;
       
        Game _context;
        Bitmap _bitmap;

        private int X;
        private int Y;

        //define X and Y 
        public int left { get { return X; } set { X = value; } }
        public new int Top { get { return Y; } set { Y = value; } }


        // mapdesign take different data
        public MapDesign(Game g, Bitmap _resource)
        {
            _context = g;
            _bitmap = new Bitmap(_resource);
        }

        //define the image
        public void drawImage(Graphics gfx)
        {
            gfx.DrawImage(_bitmap, X, Y);
        }
    }
}