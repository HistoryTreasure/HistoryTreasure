using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITI.HistoryTreasures.Rendering
{
    public partial class MenuControl : UserControl
    {
        GameControl gc = new GameControl();
        Game _g;
        
        public MenuControl()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) //Button New Game
        {
            gc.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e) //Button Continue
        {
            GameState gs = new GameState();
            gs.Load();
            Game.Themes = gs.Check();
            gc = new GameControl();
            gc.Show();
            Hide();
        }

        public Game Game
        {
            get { return _g; }
        }
    }
}
