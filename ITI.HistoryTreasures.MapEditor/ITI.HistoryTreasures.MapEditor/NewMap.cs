using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITI.HistoryTreasures.MapEditor
{
    public partial class NewMap : Form
    {
        private int _width;
        private int _height;
        private Map m;

        public NewMap()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button save.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            m = new Map(_width,_height);
            Close();
        }

        /// <summary>
        /// Button Cancel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Width textbox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _width = Convert.ToInt32(numericUpDown1.Value);
        }

        /// <summary>
        /// Height textbox.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            _height = Convert.ToInt32(numericUpDown2.Value);
        }

        
    }
}
