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
        GameControl gc;
        RiddleControl rc;
        Game _g;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuControl"/> class.
        /// </summary>
        public MenuControl()
        {
            InitializeComponent();
            rulesControl1.Hide();
        }

        /// <summary>
        /// Gets the game.
        /// </summary>
        /// <value>
        /// The game.
        /// </value>
        public Game Game
        {
            get { return _g; }
            set { _g = value; }
        }

        /// <summary>
        /// Gets the Game control
        /// </summary>
        public GameControl GameControl
        {
            get { return gc; }
            set { gc = value; }
        }

        public RiddleControl RiddleControl
        {
            get { return rc; }
            set { rc = value; }
        }

        /// <summary>
        /// Handles the Click event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e) //Button New Game
        {
            gc.Show();
            Hide();
        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e) //Button Continue
        {
            GameState gs = new GameState(Game);
            gs.Load();
            Game.Themes = gs.Check();
            gc.LevelContext = Game.Check();
            rc.LevelContext = Game.Check();
            gc.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e) //Button rules
        {
            RulesControl rc = rulesControl1;
            rc.Show();
        }
    }
}
