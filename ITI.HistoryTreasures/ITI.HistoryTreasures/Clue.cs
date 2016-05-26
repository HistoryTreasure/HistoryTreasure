using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures
{
    public class Clue
    {
        readonly string _name;
        readonly Level _lCtx;
        readonly int _x;
        readonly int _y;
        readonly Hitbox _hitbox;
        readonly string _speech;
        string _bitMapName;

        /// <summary>
        /// Initializes a new instance of the <see cref="Clue"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="lCtx">The Level CTX.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="speech">The speech.</param>
        public Clue(string name, Level lCtx, string bitMapName, int x, int y, string speech)
        {
            _name = name;
            _lCtx = lCtx;
            _bitMapName = bitMapName;
            _x = x;
            _y = y;
            _speech = speech;
            _hitbox = new Hitbox(x - 16, y, x + 16, y + 16);

            for (int i = 0; i < lCtx.Clues.Count; i++)
            {
                if (lCtx.Clues[i].Name == name)
                {
                    throw new InvalidOperationException("You cannot create two clues with same name");
                }
            }
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
        /// Gets the name of the bit map.
        /// </summary>
        /// <value>
        /// The name of the bit map.
        /// </value>
        public string BitMapName
        {
            get { return _bitMapName; }
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
        public Hitbox HitBox
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
