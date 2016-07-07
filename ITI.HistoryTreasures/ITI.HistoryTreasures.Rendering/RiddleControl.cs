﻿using System;
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
    public partial class RiddleControl : UserControl
    {
        Label _riddle;
        Level _lCtx;
        TextBox _answerUser;


        //RiddleManager _riddleManager;
        public RiddleControl()
        {
            InitializeComponent();

            this._riddle = new Label();
            this._riddle.Size = new Size(590, 61);
            this.Controls.Add(this._riddle);


        }

        /// <summary>
        /// Gets or sets the level context.
        /// </summary>
        /// <value>
        /// The level context.
        /// </value>
        public Level LevelContext
        {
            get { return _lCtx; }
            set { _lCtx = value; }
        }

        /// <summary>
        /// change the correct riddle with the level
        /// </summary>
        private void UpdateFromLevelContext()
        {
            _riddle.Text = LevelContext.Riddle;
            label2.Text = "Thème " + LevelContext.Theme.Name + ", niveau " + LevelContext.Name;

        }

        /// <summary>
        /// change the riddle on the screen
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateFromLevelContext();
        }

        
        /// <summary>
        /// button use to validate the answer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == _lCtx.Answer)
            {
                LevelContext.HasReply = true;
                textBox1.Enabled = false;
                MessageBox.Show("Bonne réponse, dirigez-vous vers la sortie !");
                _lCtx.IsOpen = true;
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Entrez la réponse s'il-vous-plaît.");
            }
            else
            {
                textBox1.Text = "";
                MessageBox.Show("Mauvaise réponse, réessayer !");
            }
        }


    }
}
