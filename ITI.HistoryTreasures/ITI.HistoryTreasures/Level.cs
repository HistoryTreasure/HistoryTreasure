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
        List<PNJ> _pnj;
        Theme _ctx;
        MainCharacter _mainCharacter;
        Map _mCtx;

        /// <summary>
        /// This constructor create a level.
        /// </summary>
        /// <param name="ctx">This parameter reference the theme of the level.</param>
        /// <param name="name">This parameter reference name of level.</param>
        public Level(Theme ctx, string name)
        {
            _ctx = ctx;
            _name = name;
            _isFinish = false;
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
        public List<PNJ> Pnj
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

        public PNJ CreatePNJ(Game gctx, int X, int Y, string bitMapName, string name, string speech)
        {
            PNJ p = new PNJ(gctx, this, X, Y, bitMapName, name, speech);
            _pnj.Add(p);
            return p;
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
    }
}