using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Drawing.Drawing2D;
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
        ResourcesManager _resourcesManager;
        Sound _sound;
        static readonly int TileSize = 32;
        Bitmap characterBitmap;
        bool right = false;
        Bitmap _backGround;
        RulesControl rc;
        RiddleControl rd;
        InteractionsControl iC;

        /// <summary>
        /// This constructor instantiate GameControl. 
        /// </summary>
        public GameControl()
        {
            _resourcesManager = new ResourcesManager();
            InitializeComponent();
            _sound = new Sound();
            _sound.PlayMusic = true;
            _sound.Play();
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
            set
            {
                if (_lCtx != value)
                {
                    if (value == null)
                    {
                        Debug.Assert(_backGround != null);
                        _backGround.Dispose();
                        _backGround = null;
                        _lCtx = null;
                        return;
                    }

                    _lCtx = value;
                    _sound.GetLevel = LevelContext.Name;

                    if (_backGround == null)
                    {
                        _backGround = new Bitmap(32 * 30, 32 * 30);
                    }

                    using (Graphics g = Graphics.FromImage(_backGround))
                    {
                        Tile[,] tileArray = LevelContext.MapContext.TileArray;
                        for (int i = 0; i < LevelContext.MapContext.Height; i++)
                        {
                            for (int j = 0; j < LevelContext.MapContext.Width; j++)
                            {
                                Tile t = tileArray[i, j];
                                Bitmap tileBitmap = GetResourcesManager.GetTileBitmap(t);
                                Debug.Assert(t.posY == i * 32 && t.posX == j * 32);
                                g.DrawImage(tileBitmap, t.posX, t.posY);
                            }
                        }
                    }
                }
            }
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

            if (LevelContext.IsFinish)
            {
                RdControl.LevelContext = GameContext.Check();
                RdControl.textBox1.Enabled = true;
                RdControl.textBox1.Text = "";
                InteractionControl.PnJinteractionBox.Text = "";
                InteractionControl.ClueinteractionBox.Text = "";
                LevelContext = GameContext.Check();
            }
            
                

            if (LevelContext.CanAnswer() && LevelContext.HasReply == false)
            {
                RdControl.textBox1.Enabled = true;
            }
            else
            {
                RdControl.textBox1.Enabled = false;
            }

            Tile[,] tileArray = LevelContext.MapContext.TileArray;
            float coefX = 1.0f * Width / (tileArray.GetLength(0) * TileSize);
            float coefY = 1.0f * Height / (tileArray.GetLength(1) * TileSize);

            e.Graphics.ScaleTransform(coefX, coefY);
            e.Graphics.DrawImage(_backGround, 0, 0);

            MainCharacter MC = LevelContext.MainCharacter;

            characterBitmap = GetResourcesManager.GetCharacterBitmap(MC);
            e.Graphics.DrawImage(characterBitmap, MC.positionX, MC.positionY);

            foreach (PNJ pnj in LevelContext.Pnjs)
            {
                Bitmap pnjBitmap = GetResourcesManager.GetCharacterBitmap(pnj);
                e.Graphics.DrawImage(pnjBitmap, pnj.positionX, pnj.positionY);
            }

            foreach (Clue clue in LevelContext.Clues)
            {
                Bitmap clueBitmap = GetResourcesManager.GetClueBitmap(clue);
                e.Graphics.DrawImage(clueBitmap, clue.X, clue.Y);
            }

            
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GameControl
            // 
            this.DoubleBuffered = true;
            this.Name = "GameControl";
            this.Size = new System.Drawing.Size(625, 583);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameControl_KeyDown);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Gets the get resources manager.
        /// </summary>
        /// <value>
        /// The get resources manager.
        /// </value>
        private ResourcesManager GetResourcesManager
        {
            get { return _resourcesManager; }
        }

        /// <summary>
        /// Returns the Sound
        /// </summary>
        public Sound PlaySound
        {
            get { return _sound; }
        }

        /// <summary>
        /// Handles the KeyDown event of the GameControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
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
            else if (e.KeyCode == Keys.Escape)
            {
                rc.Show();
            }
        }

        /// <summary>
        /// </summary>
        /// <value>
        /// The rc.
        /// </value>
        public RulesControl Rc
        {
            get { return rc; }
            set { rc = value; }
        }

        /// <summary>
        /// Gets or sets the mc bitmap.
        /// </summary>
        /// <value>
        /// The mc bitmap.
        /// </value>
        public Bitmap MCBitmap
        {
            get { return characterBitmap; }
            set { characterBitmap = value; }
        }

        /// <summary>
        /// Gets or sets the rd control.
        /// </summary>
        /// <value>
        /// The rd control.
        /// </value>
        public RiddleControl RdControl
        {
            get { return rd; }
            set { rd = value; }
        }

        /// <summary>
        /// Gets or sets the interactions control.
        /// </summary>
        /// <value>
        /// The interactions control.
        /// </value>
        public InteractionsControl InteractionControl
        {
            get { return iC; }
            set { iC = value; }
        }
    }
}
