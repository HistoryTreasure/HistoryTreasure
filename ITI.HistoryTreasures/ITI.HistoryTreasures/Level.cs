using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.HistoryTreasures
{
    public class Level
    {
        readonly string _name;
        bool _isFinish;
        readonly List<PNJ> _pnjs;
        readonly PNJ _pnj;
        readonly Theme _ctx;
        readonly MainCharacter _mainCharacter;
        public List<Clue> _clues;
        readonly Clue _clue;
        readonly Map _mCtx;
        bool _isOpen;

        /// <summary>
        /// This constructor create a level.
        /// </summary>
        /// <param name="ctx">This parameter reference the theme of the level.</param>
        /// <param name="name">This parameter reference name of level.</param>
        public Level(Theme ctx, string name)
        {
            for (int i = 0; i < ctx.Levels.Count; i++)
            {
                if (ctx.Levels[i].Name == name)
                {
                    throw new InvalidOperationException("You cannot create two levels with same name");
                }
            }

            _ctx = ctx;
            _name = name;
            _isFinish = false;
            _mainCharacter = CreateMain(ctx, 0, 0, CharacterEnum.MCFACE, "Judd");
            _pnjs = new List<PNJ>();
            //_pnj = CreatePNJ(Theme.Game, 0, 16, CharacterEnum.GUARDFACE, "lol", "zd !");
            //_pnj = CreatePNJ(Theme.Game, 0, 32, CharacterEnum.GUARDFACE, "re", "qdzqdz !");
            _pnj = CreatePNJ(Theme.Game, 48, 48, CharacterEnum.GUARDFACE, "Kiu", "Dldldldzqdqdqzdldldldldldldldl !");
            _mCtx = new Map(this, 10, 10);
            _clues = new List<Clue>();
            _clue = CreateClue(this.Theme, 128, 128, ClueEnum.LIVRE, "Livre",
                "You want to know the true ? Sorry I didn't do that");
        }

        /// <summary>
        /// This properties return the name of the level.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Return the PNJ list.
        /// </summary>
        /// <value>
        /// The PNJ.
        /// </value>
        public List<PNJ> Pnjs
        {
            get { return _pnjs; }
        }

        /// <summary>
        /// Gets the clues.
        /// </summary>
        /// <value>
        /// The clues.
        /// </value>
        public List<Clue> Clues
        {
            get { return _clues; }
        }

        /// <summary>
        /// Gets the clue.
        /// </summary>
        /// <value>
        /// The clue.
        /// </value>
        public Clue Clue
        {
            get { return _clue; }
        }

        /// <summary>
        /// This properties return if a level is finish.
        /// </summary>
        public bool IsFinish
        {
            get { return _isFinish; }
            set { _isFinish = value; }
        }

        /// <summary>
        /// This property returns the theme of the level.
        /// </summary>
        public Theme Theme
        {
            get { return _ctx; }
        }

        /// <summary>
        /// This property returns PNJ.
        /// </summary>
        public PNJ Pnj
        {
            get { return _pnj; }
        }

        /// <summary>
        /// Creates the PNJ.
        /// </summary>
        /// <param name="gctx">The GCTX.</param>
        /// <param name="X">The x position .</param>
        /// <param name="Y">The y position.</param>
        /// <param name="bitMapName">Name of the bit map.</param>
        /// <param name="name">The name.</param>
        /// <param name="speech">The speech.</param>
        /// <returns></returns>
        public PNJ CreatePNJ(Game gctx, int X, int Y, CharacterEnum bitMapName, string name, string speech)
        {
            PNJ p = new PNJ(gctx, this, X, Y, bitMapName, name, speech);
            return p;
        }

        /// <summary>
        /// Creates the main.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="bitMapName">Name of the bit map.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">you cannot create two main character</exception>
        public MainCharacter CreateMain(Theme ctx, int x, int y, CharacterEnum bitMapName, string name)
        {
            if (MainCharacter != null)
            { throw new InvalidOperationException("you cannot create two main character"); }

            return new MainCharacter(ctx.Game, this, x, y, bitMapName, name);
        }

        /// <summary>
        /// Creates the clue.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="bitMapName">Name of the bit map.</param>
        /// <param name="name">The name.</param>
        /// <param name="speech">The speech.</param>
        /// <returns></returns>
        public Clue CreateClue(Theme ctx, int x, int y, ClueEnum bitMapName, string name, string speech)
        {
            Clue c = new Clue(name, this, bitMapName, x, y, speech);
            _clues.Add(c);
            return c;
        }

        /// <summary>
        /// Gets the main character.
        /// </summary>
        /// <value>
        /// The main character.
        /// </value>
        public MainCharacter MainCharacter
        {
            get { return _mainCharacter; }
        }

        /// <summary>
        /// Interactions the with PNJ.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string InteractionWithPNJ(KeyEnum key)
        {
            string _talk = "";
            for (int i = 0; i < _pnjs.Count; i++)
            {
                if (((_mainCharacter.HitBox.xA - _pnjs[i].HitBox.xA > 32) || (_mainCharacter.HitBox.xA - _pnjs[i].HitBox.xA < 33))
                    || ((_pnjs[i].HitBox.xA - _mainCharacter.HitBox.xA > 32) || (_pnjs[i].HitBox.xA - _mainCharacter.HitBox.xA < 33))
                    && ((_pnjs[i].HitBox.yA - _mainCharacter.HitBox.yA > 32) || (_pnjs[i].HitBox.yA - _mainCharacter.HitBox.yA < 33))
                    || ((_mainCharacter.HitBox.yA - _pnjs[i].HitBox.yA > 32) || (_mainCharacter.HitBox.yA - _pnjs[i].HitBox.yA < 33)))
                {
                    key = KeyEnum.action;
                    _talk = _pnjs[i].Speech;
                    break;
                }
            }
            return _talk;
        }

        /// <summary>
        /// Gets the map context.
        /// </summary>
        /// <value>
        /// The map context.
        /// </value>
        public Map MapContext
        {
            get { return _mCtx; }
        }

        /// <summary>
        /// Interactionses the with clue.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string InteractionsWithClue(KeyEnum key)
        {
            string _speech = "";
            for (int i = 0; i < _clues.Count; i++)
            {
                if (((_mainCharacter.HitBox.xA - _clues[i].HitBox.xA > 32) || (_mainCharacter.HitBox.xA - _clues[i].HitBox.xA < 33))
                   || ((_clues[i].HitBox.xA - _mainCharacter.HitBox.xA > 32) || (_clues[i].HitBox.xA - _mainCharacter.HitBox.xA < 33))
                   && ((_clues[i].HitBox.yA - _mainCharacter.HitBox.yA > 32) || (_clues[i].HitBox.yA - _mainCharacter.HitBox.yA < 33))
                   || ((_mainCharacter.HitBox.yA - _clues[i].HitBox.yA > 32) || (_mainCharacter.HitBox.yA - _clues[i].HitBox.yA < 33)))
                {
                    key = KeyEnum.action;
                    _speech = _clues[i].Speech;
                    return _speech;
                }
                else
                {
                    break;
                }
            }
            return "";
        }

        /// <summary>
        /// Gets a value indicating whether this instance is open.
        /// Allow to quit the level when user win.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is open; otherwise, <c>false</c>.
        /// </value>
        public bool IsOpen
        {
            get { return _isOpen; }
        }
    }
}