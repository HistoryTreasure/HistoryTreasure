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
        Level _lCtx;
        ResourcesManager _resourcesManager;

        //RiddleManager _riddleManager;
        public RiddleControl()
        {
            _resourcesManager = new ResourcesManager();
            InitializeComponent();
        }

        public Level LevelContext
        {
            get { return _lCtx; }
            set { _lCtx = value; }
        }



        private ResourcesManager GetResourcesManager
        {
            get { return _resourcesManager; }
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            e.Graphics.DrawString();
        }




    }
}
