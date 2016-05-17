
using ITI.HistoryTreasures.Rendering.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures.Rendering
{
    class CMouse : MapDesign
    {
        private Rectangle _mouseHotSpot = new Rectangle();
        
        public CMouse(Game g)
            : base(g, Properties.Resources.Mole)
        {
            _mouseHotSpot.X = left + 20;
            _mouseHotSpot.Y = Top - 1;
            _mouseHotSpot.Width = 30;
            _mouseHotSpot.Height = 40;

        }
        /// <summary>
        /// position of the mouse
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

        public bool Hit(int X, int Y)
        {
            Rectangle c = new Rectangle(X, Y, 1, 1);

            if (_mouseHotSpot.Contains(c))
            {
                return true;
            }
            return false;

        }
    }
}