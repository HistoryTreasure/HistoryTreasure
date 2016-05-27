using System;
using System.CodeDom;
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

            if (X < 0 || Y < 0)
            {
                throw new ArgumentException("You cannot create a PNJ with this coordonate");
            }

            for (int i = 0; i < lCtx.Clues.Count; i++)
            {
                if (lCtx.Clues[i].Name == name)
                {
                    throw new InvalidOperationException("You cannot create two clues with same name.");
                }

                else if (lCtx.Clues[i].Speech == speech)
                {
                    throw new InvalidOperationException("You cannot have the same speech twice.");
                }
            }

            if ((X < 16) || (Y < 16) || (X > (lCtx.MapContext.TileArray.GetLength(0) * 32 - 16) || (Y > (lCtx.MapContext.TileArray.GetLength(1) * 32 - 16))))
{
                throw new ArgumentException("You cannot create a clue outside the map.");
            }

            if (LCtx.Clues.Count != 0)
            {
                foreach (Clue c in LCtx.Clues)
                {
                    if (c.X == X && c.Y == Y)
                    {
                        throw new InvalidOperationException("You cannot create two clues on same position.");
                    }
                }
            }

            if (LCtx.PNJ.Count != 0)
            {
                foreach (PNJ p in LCtx.PNJ)
                {
                    if (p.positionX == X && p.positionY == Y)
                    {
                        throw new InvalidOperationException("You cannot create Clue on PNJ.");
                    }
                }
            }

            if (LCtx.MainCharacter.positionX == X && LCtx.MainCharacter.positionY == Y)
            {
                throw new InvalidOperationException("You cannot create Clue on MainCharacter.");
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
        public Level LCtx
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
