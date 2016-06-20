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
    public partial class InteractionsControl : UserControl
    {
        private Label _ClueinteractionBox;
        private Label _PNJinteractionBox;
        private string _interactionText = "";
        private int index = 0;

        public string InteractionText
        {
            get { return _interactionText; }
            set
            {
                _interactionText = value;
                index++;
                if (index == 7)
                {
                    _ClueinteractionBox.Text = ("\r\n") + _interactionText;
                    index = 1;
                }
                else
                {
                    _ClueinteractionBox.Text += ("\r\n") + _interactionText;
                }
            }
        }

        public InteractionsControl()
        {
            this._ClueinteractionBox = new Label();
            this._ClueinteractionBox.Location = new Point(0, 0);
            this._ClueinteractionBox.Size = new Size(170, 225);
            this._ClueinteractionBox.Text = "";
            this.Controls.Add(this._ClueinteractionBox);

            this._PNJinteractionBox = new Label();
            this._PNJinteractionBox.Location = new Point(0, 250);
            this._PNJinteractionBox.Size = new Size(170, 225);
            this._PNJinteractionBox.Text = "";
            this.Controls.Add(this._PNJinteractionBox);
        }


    }
}
