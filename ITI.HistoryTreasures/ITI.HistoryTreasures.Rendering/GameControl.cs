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
        private IContainer _components;
        ResourcesManager _resourcesManager;
        Sound _sound;
        static readonly int TileSize = 32;
        Bitmap characterBitmap;
        private bool right = false;

        /// <summary>
        /// This constructor instantiate GameControl. 
        /// </summary>
        public GameControl()
        {
            _resourcesManager = new ResourcesManager();
            InitializeComponent();
            PlaySound();
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
        /// Gets the arround.
        /// </summary>
        /// <returns></returns>
        public int GetArround(double value)
        {
            return (int)(Math.Floor(value));
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
            float coefX = Width / (tileArray.GetLength(0) * TileSize);
            float coefY = Height / (tileArray.GetLength(1) * TileSize);
            int screenTileWidth = GetArround(coefX * TileSize);
            int screenTileHeight = GetArround(coefY * TileSize);

            e.Graphics.ScaleTransform(coefX,coefY);
            //e.Graphics.RotateTransform(25);
            
            Pen p = new Pen(Color.Red, 3);

            MainCharacter MC = LevelContext.MainCharacter;

            //Resizing the Form to an almost perfect square
            //  HistoryTreasures.ActiveForm.Size = new Size(this.Height,this.Height);

            for (int i = 0; i < LevelContext.MapContext.Height; i++)
            {
                for (int j = 0; j < LevelContext.MapContext.Width; j++)
                {
                    Tile t = tileArray[i, j];
                    Bitmap tileBitmap = GetResourcesManager.GetTileBitmap(t);
                    e.Graphics.DrawImage(tileBitmap, GetArround(coefX * t.posX), GetArround(coefY * t.posY));

                    if (t.IsSolid)
                    {
                        Rectangle rt = new Rectangle(GetArround(coefX * t.TileHitbox.xA), GetArround(coefY * t.TileHitbox.yA), screenTileWidth, screenTileHeight);
                        //e.Graphics.DrawRectangle(p, rt);
                    }

                    x += screenTileWidth;
                }
                x = 0;
                y += screenTileHeight;
            }

            characterBitmap = GetResourcesManager.GetCharacterBitmap(MC);
            e.Graphics.DrawImage(characterBitmap, GetArround(coefX * MC.positionX), GetArround(coefY * MC.positionY), screenTileWidth, screenTileHeight);

            Rectangle r = new Rectangle(GetArround(coefX * MC.HitBox.xA), GetArround(coefY * MC.HitBox.yA), screenTileWidth, screenTileHeight / 2);
            //e.Graphics.DrawRectangle(p, r);

            foreach (PNJ pnj in LevelContext.Pnjs)
            {
                Bitmap pnjBitmap = GetResourcesManager.GetCharacterBitmap(pnj);
                e.Graphics.DrawImage(pnjBitmap, GetArround(coefX * pnj.positionX), GetArround(coefY * pnj.positionY), screenTileWidth, screenTileHeight);

                Rectangle r2 = new Rectangle(GetArround(coefX * pnj.HitBox.xA), GetArround(coefY * pnj.HitBox.yA), screenTileWidth, screenTileHeight / 2);
                //e.Graphics.DrawRectangle(p, r2);
            }

            foreach (Clue clue in LevelContext.Clues)
            {
                Bitmap clueBitmap = GetResourcesManager.GetClueBitmap(clue);
                e.Graphics.DrawImage(clueBitmap, GetArround(coefX * clue.X), GetArround(coefY * clue.Y), screenTileWidth, screenTileHeight);

                Rectangle r3 = new Rectangle(GetArround(coefX * clue.HitBox.xA), GetArround(coefY * clue.HitBox.yA), screenTileWidth, screenTileHeight);
                //e.Graphics.DrawRectangle(p, r3);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GameControl
            // 
            this.DoubleBuffered = true;
            this.Name = "GameControl";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameControl_KeyDown);
            this.ResumeLayout(false);

        }

        private ResourcesManager GetResourcesManager
        {
            get { return _resourcesManager; }
        }

        private Sound PlaySound()
        {
            _sound = new Sound();
            return _sound;
        }

        private void GameControl_KeyDown(object sender, KeyEventArgs e)
        {
            MainCharacter MC = LevelContext.MainCharacter;
            
            if (e.KeyCode == Keys.Z)
            {
                MC.Movement(KeyEnum.up);
                if (right == true)
                {
                    MC.CharacterBitmapName = CharacterEnum.MCBACKLEFT;
                    right = false;
                }
                else
                {
                    MC.CharacterBitmapName = CharacterEnum.MCBACKRIGHT;
                    right = true;
                }
                Invalidate();
            }
            else if (e.KeyCode == Keys.S)
            {
                MC.Movement(KeyEnum.down);
                if (right == true)
                {
                    MC.CharacterBitmapName = CharacterEnum.MCFACELEFT;
                    right = false;
                }
                else
                {
                    MC.CharacterBitmapName = CharacterEnum.MCFACERIGHT;
                    right = true;
                }
                Invalidate();
            }
            else if (e.KeyCode == Keys.Q)
            {
                MC.Movement(KeyEnum.left);
                if (right == true)
                {
                    MC.CharacterBitmapName = CharacterEnum.MCLEFTLEFT;
                    right = false;
                }
                else
                {
                    MC.CharacterBitmapName = CharacterEnum.MCLEFTRIGHT;
                    right = true;
                }
                Invalidate();
            }
            else if (e.KeyCode == Keys.D)
            {
                MC.Movement(KeyEnum.right);
                if (right == true)
                {
                    MC.CharacterBitmapName = CharacterEnum.MCRIGHTLEFT;
                    right = false;
                }
                else
                {
                    MC.CharacterBitmapName = CharacterEnum.MCRIGHTRIGHT;
                    right = true;
                }
                Invalidate();
            }
            else if (e.KeyCode == Keys.E)
            {
                if (MC.Interact(KeyEnum.action) == "")
                {
                    return;
                }
                
                HistoryTreasures parent = (HistoryTreasures)this.ParentForm;
                parent.IsInteractionAClue(MC.IsClue);
                parent.SetInteractionMessage(MC.Interact(KeyEnum.action));

            }
        }

        public Bitmap MCBitmap
        {
            get { return characterBitmap; }
            set { characterBitmap = value; }
        }
    }
}
