
using ITI.HistoryTreasures.Rendering.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures.Rendering
{
    //this class have no access on the form
    //Mapdesign  give  detail
    class CMouse : MapDesign
    {
        private Rectangle _mouseHotSpot = new Rectangle();

        //access to the image
        public CMouse(Game g)
            : base(g, Properties.Resources.eau)
        {
            _mouseHotSpot.X = left + 20;
            _mouseHotSpot.Y = Top - 1;
            _mouseHotSpot.Width = 30;
            _mouseHotSpot.Height = 40;

        }
        /// <summary>
        ///Put the image at the correct position on the screen
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void Update(int X, int Y)
        {
            left = X;
            Top = Y;
            _mouseHotSpot.X = left + 20;
            _mouseHotSpot.Y = Top -1;
        }
    }
}