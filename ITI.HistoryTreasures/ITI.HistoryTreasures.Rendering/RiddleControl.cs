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
    public partial class RiddleControl : UserControl
    {
        Label _riddle;
        Level _lCtx;

        //RiddleManager _riddleManager;
        public RiddleControl()
        {
            InitializeComponent();

            this._riddle = new Label();
            this._riddle.Size = new Size(584, 61);
            this.Controls.Add(this._riddle);
        }

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
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateFromLevelContext();
        }

    }
}
