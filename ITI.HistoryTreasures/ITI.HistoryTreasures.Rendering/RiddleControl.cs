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
            //InitializeComponent();
            
            this._riddle = new Label();
            this._riddle.Size = new Size(584, 61);
            //this._riddle.Text = "level:" + _lCtx;
            this._riddle.Text = "En quelle année a eu lieu la prise de la Bastille ?";
            this.Controls.Add(this._riddle);
        }

        public Level LevelContext
        {
            get { return _lCtx; }
            set
            {
                if( _lCtx != value )
                {
                    _lCtx = value;
                    UpdateFromLevelContext();
                }
            }
        }
        /// <summary>
        /// change the correct riddle with the level
        /// </summary>
        private void UpdateFromLevelContext()
        {

        }



        //private void RiddleControl(object sender, EventArgs e)
        //{
        //    this._riddle = new Label();
        //    this._riddle.Text = "efje";  
        //}



        //protected override void OnPaint(PaintEventArgs e)
        //{

        //    //e.Graphics.DrawString();
        //}




    }
}
