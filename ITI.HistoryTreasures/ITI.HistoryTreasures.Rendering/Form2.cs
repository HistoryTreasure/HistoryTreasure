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
    public partial class Form2 : Form
    {
        Game _gCtx;
        Theme _tCtx;
        Level _lCtx;
        string _name;
        HistoryTreasures frm;

        public Form2()
        {
            InitializeComponent();
            //_gCtx.Check();
        }

        private void button2_Click(object sender, EventArgs e) //Button new game
        {
            frm = new HistoryTreasures();
            frm.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e) //Button continue
        {
            frm = new HistoryTreasures();
            GameState gm = new GameState();
            gm.Check();
            frm.Show();
            Hide();
        }
    }
}
