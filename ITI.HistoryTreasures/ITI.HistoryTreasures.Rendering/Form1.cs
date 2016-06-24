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
        
        Bitmap _herb = Properties.Resources.herbe;
        Theme _tCtx;
        Level _level;
        Game g;

        /// <summary>
        /// This contructor instantiate HistoryTreasures.
        /// </summary>
        public HistoryTreasures()
        {
            InitializeComponent();
            Game g = new Game();
            gameControl1.LevelContext = g.Check();
        }

        /// <summary>
        /// This method update position of the mouse for show it on screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HistoryTreasures_MouseMove(object sender, MouseEventArgs e)
        {

            _cursX = e.X;
            _cursY = e.Y;

            this.Refresh();
        }

        private void gameControl1_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void RiddleControl(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void interactionsControl1_Load(object sender, EventArgs e)
        {
        }

        private void gameControl1_Load(object sender, EventArgs e)
        {

        }

        private void riddleControl1_Load(object sender, EventArgs e)
        {

        }

        private void menuControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
