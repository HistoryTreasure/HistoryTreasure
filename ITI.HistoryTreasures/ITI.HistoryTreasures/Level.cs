using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ITI.HistoryTreasures
{
    public class Level
    {
        readonly string _name;
        bool _isFinish;
        readonly List<PNJ> _pnjs;
        readonly Theme _ctx;
        readonly MainCharacter _mainCharacter;
        public readonly List<Clue> _clues;
        Dictionary<string, string> _riddles;
        Dictionary<string, string> _answers;
        readonly Map _mCtx;
        bool _isOpen;
        bool _hasReply = false;
        
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
            AddPnj(Name);
            _mCtx = new Map(this);
            _clues = new List<Clue>();
            AddClues(Name);
            _answers = new Dictionary<string, string>();
            CreateAnswer();
            _riddles = new Dictionary<string, string>();
            CreateRiddle();
        }

        /// <summary>
        /// Creates the anwser.
        /// </summary>
        /// <returns>The answer</returns>
        void CreateAnswer()
        {
            _answers.Add("1_1", "1789");
            _answers.Add("1_2", "louis xvi");
            _answers.Add("1_3", "1799");
        }

        /// <summary>
        /// This property returns the answer of the Level.
        /// </summary>
        public string Answer
        {
            get { return _answers[Name]; }
        }

        /// <summary>
        /// This property returns the name of the Level.
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
        /// Gets the clues list.
        /// </summary>
        /// <value>
        /// The clues list.
        /// </value>
        public List<Clue> Clues
        {
            get { return _clues; }
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
        /// Creates a PNJ.
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
        /// Creates a clue.
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
            string talk = "";

            for (int i = 0; i < Pnjs.Count; i++)
            {
                if (MainCharacter.CanInteract(Pnjs[i].HitBox))
                {
                    if (Pnjs[i].positionX - MainCharacter.positionX > 0 )
                    {
                        Pnjs[i].CharacterBitmapName = SetCharacterBitmap(Pnjs[i].Name, "left");
                    }
                    else if (Pnjs[i].positionY - MainCharacter.positionY > 0)
                    {
                        Pnjs[i].CharacterBitmapName = SetCharacterBitmap(Pnjs[i].Name, "up");
                    }
                    else if (Pnjs[i].positionX - MainCharacter.positionX < 0 )
                    {
                        Pnjs[i].CharacterBitmapName = SetCharacterBitmap(Pnjs[i].Name, "right");
                    }
                    else if (Pnjs[i].positionY - MainCharacter.positionY < 0)
                    {
                        Pnjs[i].CharacterBitmapName = SetCharacterBitmap(Pnjs[i].Name, "down");
                    }

                    talk = Pnjs[i].Name + (": ") + Pnjs[i].Speech;
                    Pnjs[i].Talk = true;
                    break;
                }
            }
            CanAnswer();
            return talk;
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

            for (int i = 0; i < Clues.Count; i++)
            {
                if (MainCharacter.CanInteract(Clues[i].HitBox))
                {
                    _speech = Clues[i].Name + (": ") + Clues[i].Speech;
                    Clues[i].Talk = true;
                    break;
                }
            }
            CanAnswer();
            return _speech;
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
            set { _isOpen = value; }
        }

        /// <summary>
        /// Gets the riddle.
        /// </summary>
        /// <value>
        /// The riddle.
        /// </value>
        public string Riddle
        {
            get { return _riddles[Name]; }
        }

        /// <summary>
        /// Adds the PNJ.
        /// </summary>
        /// <returns></returns>
        public List<PNJ> AddPnj(string name)
        {
            if (name == "1_1")
            {
                Pnjs.Add(CreatePNJ(Theme.Game, 10*32, 8*32, CharacterEnum.PNJGIRL, "Hawke", "Cette année nous prendrons la bastille !"));
                Pnjs.Add(CreatePNJ(Theme.Game, 15*32, 11*32, CharacterEnum.PNJCREEDRIGHT, "Kiu", "La révolution est en marche"));
            }
            else if (name == "1_2")
            {
                Pnjs.Add(CreatePNJ(Theme.Game, 22*32, 13*32, CharacterEnum.PNJUNDERTAKERLEFT, "Kuro", "Le roi est mort !"));
                Pnjs.Add(CreatePNJ(Theme.Game, 3*32, 21*32, CharacterEnum.PNJGUARD, "Shiro", "Son nombre est 16"));
            }
            else if (name == "1_3")
            {
                Pnjs.Add(CreatePNJ(Theme.Game, 23*32, 16*32, CharacterEnum.PNJGIRLRIGHT, "Murasaki", "Bonaparte a fait un coup d'état !"));
                Pnjs.Add(CreatePNJ(Theme.Game, 10*32, 13*32, CharacterEnum.PNJGUARDLEFT, "Midori", "C'est la fin de la monarchie ! Les citoyens vont enfin pouvoir reprendre le pouvoir !"));
            }
            return Pnjs;
        }

        /// <summary>
        /// Adds the clues.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public List<Clue> AddClues(string name)
        {
            if (name == "1_1")
            {
                Clues.Add(CreateClue(_ctx, 19*32, 5*32, ClueEnum.LIVRE, "Book",
                    "L'histoire se souviendra de l'an 17... le reste est illisible"));
                Clues.Add(CreateClue(_ctx, 20*32, 25*32, ClueEnum.LIVRE, "Livre",
                    "La bastille fut prise 11 ans avant la fin du siecle"));
            }

            else if (name == "1_2")
            {
                Clues.Add(CreateClue(_ctx, 9*32, 5*32, ClueEnum.LIVRE, "History",
                    "Le roi fut décapité le 21 janviers 1793"));
                Clues.Add(CreateClue(_ctx, 16*32, 26*32, ClueEnum.LIVRE, "Test",
                    "Sa mort marqua la fin de la monarchie et le début de la première république."));
            }

            else if (name == "1_3")
            {
                Clues.Add(CreateClue(_ctx, 26*32, 2*32, ClueEnum.LIVRE, "1",
                    "La fin de la révolution marqua le début du consulat."));
                Clues.Add(CreateClue(_ctx, 11*32, 26*32, ClueEnum.LIVRE, "2",
                    "Au court du siècle suivant, la France vit la naissance de la Première République !"));
            }

            return Clues;
        }

        /// <summary>
        /// Check if player can answer.
        /// </summary>
        /// <returns>true if the player can answer</returns>
        public bool CanAnswer()
        {
            bool pnj = false;
            bool clue = false;

            foreach (PNJ p in Pnjs)
            {
                if (p.Talk == true)
                {
                    pnj = true;
                }

                else
                {
                    pnj = false;
                    break;
                }
            }

            foreach (Clue c in Clues)
            {
                if (c.Talk == true)
                {
                    clue = true;
                }

                else
                {
                    clue = false;
                    break;
                }
            }

            return (clue && pnj);
        }

        /// <summary>
        /// Exits the level.
        /// </summary>
        /// <param name="X">The x.</param>
        /// <param name="Y">The y.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        internal void ExitLevel(int X, int Y)
        {
            if ((IsOpen == true) && (MapContext.TileArray[MapContext.TileArray.GetLength(0) - 1, MapContext.TileArray.GetLength(1) - 1].posX == X) && (MapContext.TileArray[MapContext.TileArray.GetLength(0) - 1, MapContext.TileArray.GetLength(1) - 1].posY == Y))
            {
                IsFinish = true;
                GameState gm = new GameState(Theme.Game);
                Theme.Game.Check();
                gm.SaveGame();
                gm.Load();
            }
        }

        /// <summary>
        /// Creates the riddle.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">The level has no riddle</exception>
        private void CreateRiddle()
        {
            _riddles.Add("1_1", "Quelle est la date de la prise de la bastille ?");
            _riddles.Add("1_2", "Quel est le nom du roi qui a été décapité ?");
            _riddles.Add("1_3", "En quelle année a eu lieu le coup d'Etat de Napoléon Bonaparte ?");
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has reply.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has reply; otherwise, <c>false</c>.
        /// </value>
        public bool HasReply
        {
            get { return _hasReply; }
            set { _hasReply = value; }
        }

        CharacterEnum SetCharacterBitmap(string name, string direction)
        {
            if (name == "Hawke")
            {
                if (direction == "left")
                {
                    return CharacterEnum.PNJGIRLLEFT;
                }
                else if (direction == "right")
                {
                    return CharacterEnum.PNJGIRLRIGHT;
                }
                else if(direction == "down")
                {
                    return CharacterEnum.PNJGIRL;
                }
            }

            if (name == "Kiu")
            {
                if (direction == "left")
                {
                    return CharacterEnum.PNJCREEDLEFT;
                }
                else if (direction == "right")
                {
                    return CharacterEnum.PNJCREEDRIGHT;
                }
                else if (direction == "down")
                {
                    return CharacterEnum.PNJCREED;
                }
            }

            if (name == "Kuro")
            {
                if (direction == "left")
                {
                    return CharacterEnum.PNJUNDERTAKERLEFT;
                }
                else if (direction == "right")
                {
                    return CharacterEnum.PNJUNDERTAKERRIGHT;
                }
                else if (direction == "down")
                {
                    return CharacterEnum.PNJUNDERTAKER;
                }
            }

            if (name == "Shiro")
            {
                if (direction == "left")
                {
                    return CharacterEnum.PNJGUARDLEFT;
                }
                else if (direction == "right")
                {
                    return CharacterEnum.PNJGUARDRIGHT;
                }
                else if (direction == "down")
                {
                    return CharacterEnum.PNJGUARD;
                }
            }

            if (name == "Murasaki")
            {
                if (direction == "left")
                {
                    return CharacterEnum.PNJGIRLLEFT;
                }
                else if (direction == "right")
                {
                    return CharacterEnum.PNJGIRLRIGHT;
                }
                else if (direction == "down")
                {
                    return CharacterEnum.PNJGIRL;
                }
            }

            if (name == "Midori")
            {
                if (direction == "left")
                {
                    return CharacterEnum.PNJGUARDLEFT;
                }
                else if (direction == "right")
                {
                    return CharacterEnum.PNJGUARDRIGHT;
                }
                else if (direction == "down")
                {
                    return CharacterEnum.PNJGUARD;
                }
            }

            return CharacterEnum.MCFACE;
        }
    }
}