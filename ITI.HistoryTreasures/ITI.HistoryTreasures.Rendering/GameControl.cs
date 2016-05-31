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
        Game _gCtx;

        /// <summary>
        /// This constructor instantiate GameControl. 
        /// </summary>
        public GameControl()
        {
            _resourcesManager = new ResourcesManager();
            InitializeComponent();
        }


        public Game GameContext
        {
            get { return _gCtx; }
            set { _gCtx = value; }
        }

        /// <summary>
        /// This property returns the level context.
        /// </summary>
        public Level LevelContext
        {
            get { return _lCtx; }
            set { _lCtx = value; }
        }


        /// <summary>
        /// This method paint element on screen.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (LevelContext == null) return;
            Tile[,] tileArray = _lCtx.MapContext.TileArray;
            //Size _windowSize = HistoryTreasures.ActiveForm.Size;
            int x = 0;
            int y = 0;
            int width = this.Width / tileArray.GetLength(0);
            int height = this.Height / tileArray.GetLength(1);

            //Resizing the Form to an almost perfect square
            //  HistoryTreasures.ActiveForm.Size = new Size(this.Height,this.Height);

            for (int i = 0; i < LevelContext.MapContext.Height; i++)
            {
                for (int j = 0; j < LevelContext.MapContext.Width; j++)
                {
                    Tile m = tileArray[i, j];

                    // Bitmap tileperso = _resourcesManager.GetTileBitmapPerso(m);
                    Tile t = tileArray[i, j];
                    Bitmap tileBitmap = GetResourcesManager.GetTileBitmap(t);
                    e.Graphics.DrawImage(tileBitmap, x, y, width, height);
                    x += this.Width / tileArray.GetLength(0);
                }
                x = 0;
                y += this.Height / tileArray.GetLength(1);
            }

            MainCharacter MC = LevelContext.MainCharacter;
            Bitmap characterBitmap = GetResourcesManager.GetCharacterBitmap(MC);
            e.Graphics.DrawImage(characterBitmap, MC.positionX -16, MC.positionY -16, width, height);

            PNJ pnj = new PNJ(_gCtx, LevelContext, 16, 128, CharacterEnum.GUARDFACE, "Hawke", "Hello");
            Bitmap pnjBitmap = GetResourcesManager.GetCharacterBitmap(pnj);
            e.Graphics.DrawImage(pnjBitmap, pnj.positionX - 16, pnj.positionY - 16, width, height);
        }
        
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GameControl
            // 
            this.DoubleBuffered = true;
            this.Name = "GameControl";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GameControl_KeyPress);
            this.ResumeLayout(false);

        }

        private void GameControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if(e == 
        }

        /*private void PaintCharacter()
        {
            
        }*/

        private ResourcesManager GetResourcesManager
        {
            get { return _resourcesManager; }
        }

    }
}
