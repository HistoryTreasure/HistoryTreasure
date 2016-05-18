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
        private IContainer components;
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
            Size _windowSize = HistoryTreasures.ActiveForm.Size;
            HistoryTreasures.ActiveForm.Size = new Size(_windowSize.Height, _windowSize.Height);

            for(int i = 0; i < _lCtx.MapContext.Height; i++)
            {
                for(int j = 0; j < _lCtx.MapContext.Width; j++)
                {
                    Tile t = tileArray[i, j];
                    Bitmap tileBitmap = _resourcesManager.GetTileBitmap(t);
                    int x = _windowSize.Width / 30;
                    int y = _windowSize.Height /  30;
                    int width = _windowSize.Width / 30;
                    int height = _windowSize.Height / 30;
                    e.Graphics.DrawImage(tileBitmap, x, y, width, height);
                    e.Graphics.DrawImage(tileBitmap, x + width, y, width, height);
                    e.Graphics.DrawImage(tileBitmap, x, y + height, width, height);
                }
            }
        }
    }
}
