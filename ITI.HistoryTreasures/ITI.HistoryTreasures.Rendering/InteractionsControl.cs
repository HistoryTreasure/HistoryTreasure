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
        private ListBox _interactionList;
        private string _interactionText;

        public string InteractionText
        {
            get { return _interactionText; }
            set
            {
                _interactionText = value;
                _interactionList.Items.Add(_interactionText);
                _interactionList.TopIndex = _interactionList.Items.Count - 1;
            }
        }

        public InteractionsControl()
        {
            this._interactionList = new ListBox();
            this._interactionList.Enabled = false;
            this._interactionList.Location = new Point(0, 0);
            this._interactionList.Size = new Size(170, 458);
            this.Controls.Add(this._interactionList);
        }

        //private Label _interactionBox;
        //private string _interactionText = "";
        //private List<string> _interactionList = new List<string>();
        //private int index = 0;

        //public string InteractionText
        //{
        //    get { return _interactionText; }
        //    set
        //    {
        //        _interactionText = value;
        //        _interactionList.Add(value);
        //        index++;
        //        _interactionBox.Text = _interactionList[index - 1];
        //    }
        //}

        //public InteractionsControl()
        //{
        //    this._interactionBox = new Label();
        //    this._interactionBox.Location = new Point(0, 0);
        //    this._interactionBox.Size = new Size(170, 457);
        //    this._interactionBox.Text = "";
        //    this.Controls.Add(this._interactionBox);
        //}


    }
}
