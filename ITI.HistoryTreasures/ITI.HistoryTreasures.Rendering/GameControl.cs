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
    public class GameControl : UserControl
    {
        Level _lCtx;
        ResourcesManager _resourcesManager;

        public GameControl()
        {
            _resourcesManager = new ResourcesManager();
        }

        public Level LevelContext
        {
            get { return _lCtx; }
            set { _lCtx = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_lCtx == null) return;
            Tile[,] tileArray = _lCtx.MapContext.TileArray;

            for(int i = 0; i < _lCtx.MapContext.Height; i++)
            {
                for(int j = 0; j < _lCtx.MapContext.Width; j++)
                {
                    Tile t = tileArray[i, j];
                    Bitmap tileBitmap = _resourcesManager.GetTileBitmap(t);
                    int x = 30;
                    int y = 30;
                    int width = 100;
                    int height = 100;
                    e.Graphics.DrawImage(tileBitmap, x, y, width, height);
                }
            }
        }
    }
}
