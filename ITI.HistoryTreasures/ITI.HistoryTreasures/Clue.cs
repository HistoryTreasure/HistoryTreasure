using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures
{
    internal class Clue
    {
        readonly string _name;
        readonly Level _lCtx;
        bool _isUsed;
        readonly int _x;
        readonly int _y;
        readonly Hitbox _hitbox;
        readonly string _speech;

        /// <summary>
        /// Initializes a new instance of the <see cref="Clue"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="lCtx">The Level CTX.</param>
        /// <param name="isUsed">If set to <c>true</c> [is used].</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="hitbox">The hitbox.</param>
        /// <param name="speech">The speech.</param>
        public Clue(string name, Level lCtx, bool isUsed, int x, int y, Hitbox hitbox, string speech)
        {
            _name = name;
            _lCtx = lCtx;
            _isUsed = isUsed;
            _x = x;
            _y = y;
            _hitbox = hitbox;
            _speech = speech;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Gets the level context.
        /// </summary>
        /// <value>
        /// The level context.
        /// </value>
        public Level LCxt
        {
            get { return _lCtx; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is used.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is used; otherwise, <c>false</c>.
        /// </value>
        public bool IsUsed
        {
            get { return _isUsed; }
            set { _isUsed = value; }
        }

        /// <summary>
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public int X
        {
            get { return _x; }
        }

        /// <summary>
        /// Gets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public int Y
        {
            get { return _y; }
        }

        /// <summary>
        /// Gets the hitbox.
        /// </summary>
        /// <value>
        /// The hitbox.
        /// </value>
        public Hitbox Hitbox
        {
            get { return _hitbox; }
        }

        /// <summary>
        /// Gets the speech.
        /// </summary>
        /// <value>
        /// The speech.
        /// </value>
        public string Speech
        {
            get { return _speech; }
        }
    }
}
