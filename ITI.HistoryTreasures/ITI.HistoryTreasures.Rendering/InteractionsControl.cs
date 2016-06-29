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
        private Label _PNJDialogBox;
        private Label _ClueDialogBox;
        private string _interactionText = "";
        private int indexClue = 0;
        private int indexPNJ = 0;
        private bool _isAClue;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is clue.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is clue; otherwise, <c>false</c>.
        /// </value>
        public bool IsClue
        {
            get { return _isAClue; }
            set { _isAClue = value; }
        }

        /// <summary>
        /// Gets or sets the interaction text.
        /// </summary>
        /// <value>
        /// The interaction text.
        /// </value>
        public string InteractionText
        {
            get { return _interactionText; }
            set
            {
                _interactionText = value;

                if (_isAClue)
                {
                    indexClue++;

                    if (indexClue == 8)
                    {
                        _ClueinteractionBox.Text = ("\r\n") + _interactionText;
                        indexClue = 1;
                    }

                    else
                    {
                        _ClueinteractionBox.Text += ("\r\n") + _interactionText;
                    }
                }

                if (!_isAClue)
                {
                    indexPNJ++;

                    if (indexPNJ == 8)
                    {
                        _PNJinteractionBox.Text = ("\r\n") + _interactionText;
                        indexPNJ = 1;
                    }

                    else
                    {
                        _PNJinteractionBox.Text += ("\r\n") + _interactionText;
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionsControl"/> class.
        /// </summary>
        public InteractionsControl()
        {
            this._ClueDialogBox = new Label();
            this._ClueDialogBox.Location = new Point(0, 0);
            this._ClueDialogBox.Size = new Size(50, 15);
            this._ClueDialogBox.Text = "Clues :";
            this.Controls.Add(this._ClueDialogBox);

            this._PNJDialogBox = new Label();
            this._PNJDialogBox.Location = new Point(0, 245);
            this._PNJDialogBox.Size = new Size(50, 15);
            this._PNJDialogBox.Text = "Dialogs :";
            this.Controls.Add(this._PNJDialogBox);

            this._ClueinteractionBox = new Label();
            this._ClueinteractionBox.Location = new Point(0, 5);
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
