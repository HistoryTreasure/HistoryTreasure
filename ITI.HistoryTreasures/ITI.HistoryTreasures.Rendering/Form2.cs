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
        Theme _tCtx;
        Level _lCtx;
        string _name;
        HistoryTreasures frm;
        Game _g;

        public Form2()
        {
            InitializeComponent();
            _g = new Game();
        }

        private void button2_Click(object sender, EventArgs e) //Button new game
        {
            frm = new HistoryTreasures(Game);
            frm.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e) //Button continue
        {
            frm = new HistoryTreasures(Game);
            GameState gm = new GameState();
            gm.Load();
            gm.Check();
            frm.Show();
            Hide();
        }

        public Game Game
        {
            get { return _g; }
        }
    }
}
