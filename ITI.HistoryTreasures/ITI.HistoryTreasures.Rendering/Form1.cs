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
        /// <summary>
        /// This contructor instantiate HistoryTreasures.
        /// </summary>
        public HistoryTreasures()
        {
            InitializeComponent();
            Game g = new Game();
            gameControl1.LevelContext = g.Check();
            menuControl1.RiddleControl = riddleControl1;
            gameControl1.RulesControl = menuControl1.RulesControl1;
            riddleControl1.LevelContext = g.Check();
            menuControl1.GameControl = gameControl1;
            menuControl1.Game = g;
        }

        /// <summary>
        /// Handles the SizeChanged event of the gameControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gameControl1_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        /// <summary>
        /// Riddles the control.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RiddleControl(object sender, EventArgs e)
        {
            this.Refresh();
        }

        /// <summary>
        /// Handles the Load event of the interactionsControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void interactionsControl1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the Load event of the gameControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void gameControl1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Load event of the riddleControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void riddleControl1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Load event of the menuControl1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void menuControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
