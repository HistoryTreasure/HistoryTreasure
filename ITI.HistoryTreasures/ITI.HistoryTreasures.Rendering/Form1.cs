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

        int _cursX = 0;
        int _cursY = 0;

        CMouse _Eau;
        Game g;

        public HistoryTreasures()
        {
            InitializeComponent();
            _Eau = new CMouse(g) { left = 10, Top = 200 };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics dc = e.Graphics;
#if  My_Debug


            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font _font = new System.Drawing.Font("Stencil", 12, FontStyle.Regular);
            TextRenderer.DrawText(dc, "X=" + _cursX.ToString() + ":" + "Y=" + _cursY.ToString(), _font,
               new Rectangle(0,0, 120, 20), SystemColors.ControlText, flags);
#endif
            _Eau.drawImage(dc);
            base.OnPaint(e);
        }


      

        private void HistoryTreasures_MouseMove(object sender, MouseEventArgs e)
        {
            

            _cursX = e.X;
            _cursY = e.Y;

            this.Refresh();

        }
    }
}
