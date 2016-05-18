#define My_Debug

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITI.HistoryTreasures.Rendering
{
    public partial class HistoryTreasures : Form
    {
        // the mouse has a cursor
        // On the screen X and Y
        int _cursX = 0;
        int _cursY = 0;

        MapDesign _Eau;
        Game g;
        Bitmap _herb = Properties.Resources.herbe;
        Theme _tCtx;

        public HistoryTreasures()
        {
            InitializeComponent();
            gameControl1.LevelContext = new Level(_tCtx, "Test"); 
        }

        /*protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
#if  My_Debug


            // the position,style and composition of X and Y
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font _font = new System.Drawing.Font("Stencil", 12, FontStyle.Regular);
            TextRenderer.DrawText(dc, "X=" + _cursX.ToString() + ":" + "Y=" + _cursY.ToString(), _font,
               new Rectangle(900,700, 120, 20), SystemColors.ControlText, flags);
#endif

            //position of the tile
            for (int ix = 0; ix < 800; ix += 32)
            {
                for (int iy = 0; iy < 600; iy += 32)
                {
                    _Eau = new MapDesign(g, _herb) { left = ix, Top = iy };
                    _Eau.drawImage(dc);
                }
            }
            
            base.OnPaint(e);
        }*/


      
        // move of the mouse 
        private void HistoryTreasures_MouseMove(object sender, MouseEventArgs e)
        {
            

            _cursX = e.X;
            _cursY = e.Y;

            this.Refresh();

        }
    }
}
