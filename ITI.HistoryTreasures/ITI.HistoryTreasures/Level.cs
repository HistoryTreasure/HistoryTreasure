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
        readonly List<PNJ> _pnj;
        readonly Theme _ctx;
        readonly MainCharacter _mainCharacter;
        readonly Map _mCtx;

        /// <summary>
        /// This constructor create a level.
        /// </summary>
        /// <param name="ctx">This parameter reference the theme of the level.</param>
        /// <param name="name">This parameter reference name of level.</param>
        public Level(Theme ctx, string name)
        {
            for(int i = 0; i < ctx.Levels.Count; i++)
            {
                if(ctx.Levels[i].Name == name)
                {
                    throw new InvalidOperationException("You cannot create two levels with same name");
                }
            }

            _ctx = ctx;
            _name = name;
            _isFinish = false;
            _mainCharacter = CreateMain(ctx,16,16,"Test", "Judd" );
            _pnj = new List<PNJ>();
            _mCtx = new Map(this, 10, 10);
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
        public List<PNJ> PNJ
        {
            get { return _pnj; }
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
        /// Creates the PNJ.
        /// </summary>
        /// <param name="gctx">The GCTX.</param>
        /// <param name="X">The x position .</param>
        /// <param name="Y">The y position.</param>
        /// <param name="bitMapName">Name of the bit map.</param>
        /// <param name="name">The name.</param>
        /// <param name="speech">The speech.</param>
        /// <returns></returns>
        public PNJ CreatePNJ(Game gctx, int X, int Y, string bitMapName, string name, string speech)
        {
            PNJ p = new PNJ(gctx, this, X, Y, bitMapName, name, speech);
            _pnj.Add(p);
            return p;
        }

        public MainCharacter CreateMain(Theme ctx, int x, int y, string bitMapName, string name)
        {
            if (MainCharacter != null)
                throw new InvalidOperationException("you cannot crate two main character");

            return new MainCharacter(ctx.Game, x, y, bitMapName, name); 

        }

        /// <summary>
        /// This property returns the MainCharacter.
        /// </summary>
        public MainCharacter MainCharacter
        {
            get { return _mainCharacter; }
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

        /*public Map CreateMap(this, List<PNJ> Pnj, MainCharacter mC)
        {
            _mCtx = new Map(this, 10, 10);

        }*/
    }
}