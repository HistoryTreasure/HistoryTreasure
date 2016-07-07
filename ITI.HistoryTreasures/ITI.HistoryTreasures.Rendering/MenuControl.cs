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
    public partial class MenuControl : UserControl
    {
        GameControl gc;
        RiddleControl rc;
        Game _g;
        RulesControl rulesControl;
        InteractionsControl iC;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuControl"/> class.
        /// </summary>
        public MenuControl()
        {
            InitializeComponent();
            rulesControl = rulesControl1;
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

        public RulesControl RulesControl1
        {
            get { return rulesControl; }
            set { rulesControl = value; }
        }

        /// <summary>
        /// Gets or sets the interactions control.
        /// </summary>
        /// <value>
        /// The interactions control.
        /// </value>
        public InteractionsControl InteractionsControl
        {
            get { return iC; }
            set { iC = value; }
        }

        /// <summary>
        /// Handles the Click event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e) //Button New Game
        {
            gc.LevelContext = Game.Check();
            gc.Show();
            iC.Show();
            rc.Show();
            Hide();
            // show the level and theme
            if (gc.LevelContext.Name == "1_1")
            {
                MessageBox.Show("Thème I niveau 1");
            }
            else if (gc.LevelContext.Name == "1_2")
            {
                MessageBox.Show("Thème I niveau 2");
            }
            else if (gc.LevelContext.Name == "1_3")
            {
                MessageBox.Show("Thème I niveau 3");
            }
            else if (gc.LevelContext.Name == "2_1")
            {
                //MessageBox.Show("Vous avez terminé le Theme I");
                MessageBox.Show("Thème II niveau 1");
            }
            else if (gc.LevelContext.Name == "2_2")
            {
                MessageBox.Show("Thème II niveau 2");
            }
            else if (gc.LevelContext.Name == "2_3")
            {
                MessageBox.Show("Thème II niveau 3");
            }
        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e) //Button Continue
        {
            GameState gs = new GameState(Game);
            //gs.Load();
            Game.Themes = gs.Check();
            gc.LevelContext = Game.Check();
            rc.LevelContext = Game.Check();
            iC.Show();
            gc.Show();
            rc.Show();
            Hide();
            // show on what level you are

            if (gc.LevelContext.Name == "1_1")
            {
                MessageBox.Show("Thème I niveau 1");
            }
            else if (gc.LevelContext.Name == "1_2")
            {
                MessageBox.Show("Thème I niveau 2");
            }
            else if (gc.LevelContext.Name == "1_3")
            {
                MessageBox.Show("Thème I niveau 3");
            }
            else if (gc.LevelContext.Name == "2_1")
            {
                MessageBox.Show("Vous avez terminé le Theme I");
                MessageBox.Show("Thème II niveau 1");
            }
            else if (gc.LevelContext.Name == "2_3")
            {
                MessageBox.Show("Thème II niveau 2");
            }
            else if (gc.LevelContext.Name == "2_3")
            {
                MessageBox.Show("Thème II niveau 3");
            }
            gc.PlaySound.Stop();
            gc.PlaySound.Play();

           
        }

        private void button4_Click(object sender, EventArgs e) //Button rules
        {
            rulesControl.Show();
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            gc.PlaySound.Stop();
            gc.PlaySound.Play();
        }
    }
}
