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

    //mouse position on the screen
    public partial class HistoryTreasures : Form
    {

        int _cursX = 0;
        int _cursY = 0;

        CMouse _souris;
        Game g;
       

        //initialize the mouse 
        public HistoryTreasures()
        {
            InitializeComponent();
            _souris = new CMouse(g) { left = 1, Top = 34 };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
#if  My_Debug


            //position of the text and option
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font _font = new System.Drawing.Font("Stencil", 12, FontStyle.Regular);
            TextRenderer.DrawText(dc, "X=" + _cursX.ToString() + ":" + "Y=" + _cursY.ToString(), _font,
               new Rectangle(0,0, 120, 20), SystemColors.ControlText, flags);
#endif
            //our images
            _souris.drawImage(dc);
            base.OnPaint(e);
        }





        // tell the cursor cordinate with a refresh
        void HistoryTreasures_MouseMove(object sender, MouseEventArgs e)
        {
            

            _cursX = e.X;
            _cursY = e.Y;

            this.Refresh();

        }
    }
}
