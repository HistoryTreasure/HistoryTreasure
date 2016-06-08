using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using ITI.HistoryTreasures.Rendering.Properties;

namespace ITI.HistoryTreasures.Rendering
{
    public class GameControl : UserControl
    {
        Level _lCtx;
        Game _gCtx;
        private IContainer components;
        ResourcesManager _resourcesManager;
        Sound _sound;

        /// <summary>
        /// This constructor instantiate GameControl. 
        /// </summary>
        public GameControl()
        {
            _resourcesManager = new ResourcesManager();
            InitializeComponent();
        }

        /// <summary>
        /// This property returns the game context.
        /// </summary>
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
            Tile[,] tileArray = LevelContext.MapContext.TileArray;
            //Size _windowSize = HistoryTreasures.ActiveForm.Size;
            int x = 0;
            int y = 0;
            int width = this.Width / tileArray.GetLength(0);
            int height = this.Height / tileArray.GetLength(1);

            MainCharacter MC = LevelContext.MainCharacter;
            int posXMC = MC.positionX*Width/tileArray.GetLength(0);
            int posYMC = MC.positionY * Height / tileArray.GetLength(1);

            int posXPNJ = LevelContext.Pnj.positionX*Width/tileArray.GetLength(0);
            int posYPNJ = LevelContext.Pnj.positionY * Height / tileArray.GetLength(1);

            //Resizing the Form to an almost perfect square
            //  HistoryTreasures.ActiveForm.Size = new Size(this.Height,this.Height);

            for (int i = 0; i < LevelContext.MapContext.Height; i++)
            {
                for (int j = 0; j < LevelContext.MapContext.Width; j++)
                {
                    Tile t = tileArray[i, j];
                    Bitmap tileBitmap = GetResourcesManager.GetTileBitmap(t);
                    e.Graphics.DrawImage(tileBitmap, x, y, width, height);
                    x += this.Width / tileArray.GetLength(0);

                    if (t.IsSolid)
                    {
                        Rectangle rt = new Rectangle(t.TileHitbox.xA, t.TileHitbox.yA, t.TileHitbox.xB - t.TileHitbox.xA,
                            t.TileHitbox.yC - t.TileHitbox.yA);
                        e.Graphics.FillRectangle(Brushes.Red, rt);
                    }
                }
                x = 0;
                y += this.Height / tileArray.GetLength(1);
            }

            Bitmap characterBitmap = GetResourcesManager.GetCharacterBitmap(MC);
            e.Graphics.DrawImage(characterBitmap, MC.positionX - 16, MC.positionY - 16, width, height);

            Rectangle r = new Rectangle(posXMC, posYMC, MC.HitBox.xB - MC.HitBox.xA, MC.HitBox.yC - MC.HitBox.yA);
            e.Graphics.FillRectangle(Brushes.Red, r);

            PNJ pnj = LevelContext.Pnjs[0];
            Bitmap pnjBitmap = GetResourcesManager.GetCharacterBitmap(pnj);
            e.Graphics.DrawImage(pnjBitmap, pnj.positionX - 16, pnj.positionY - 16, width, height);

            Clue clue = LevelContext.Clues[0];
            Bitmap clueBitmap = GetResourcesManager.GetClueBitmap(clue);
            e.Graphics.DrawImage(clueBitmap, clue.X - 16, clue.Y - 16, width, height);
            Rectangle r2 = new Rectangle(posXPNJ, posYPNJ, pnj.HitBox.xB - pnj.HitBox.xA, pnj.HitBox.yC - pnj.HitBox.yA);
            e.Graphics.FillRectangle(Brushes.Red, r2);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.DoubleBuffered = true;
            this.Name = "GameControl";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameControl_KeyDown);
            this.ResumeLayout(false);

            _sound = new Sound();
        }

        private ResourcesManager GetResourcesManager
        {
            get { return _resourcesManager; }
        }

        private void GameControl_KeyDown(object sender, KeyEventArgs e)
        {
            MainCharacter MC = LevelContext.MainCharacter;
            if (e.KeyCode == Keys.Z)
            {
                MC.Movement(KeyEnum.up);
                Invalidate();
            }
            else if (e.KeyCode == Keys.S)
            {
                MC.Movement(KeyEnum.down);
                Invalidate();
            }
            else if (e.KeyCode == Keys.Q)
            {
                MC.Movement(KeyEnum.left);
                Invalidate();
            }
            else if (e.KeyCode == Keys.D)
            {
                MC.Movement(KeyEnum.right);
                Invalidate();
            }
            else if (e.KeyCode == Keys.E)
            {
                MC.Interact(KeyEnum.action);
                MessageBox.Show(LevelContext.Pnj.Speech);
                MessageBox.Show(LevelContext.Clue.Speech);
            }
        }
    }
}
