using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.HistoryTreasures
{
    public class PNJ : Character
    {
        string _speech;
        readonly Level _ctx;

        /// <summary>
        /// This constructor allow to create a PNJ
        /// </summary>
        /// <param name="gctx">This parameter reference pnj contains in game.</param>
        /// <param name="ctx">This parameter reference pnj contains in level.</param>
        /// <param name="X">This parameter reference horizontal position with an int.</param>
        /// <param name="Y">This parameter reference vertical position with an int.</param>
        /// <param name="bitMapName">This parameter reference appaerance of Character.</param>
        /// <param name="name">This parameter reference name of PNJ.</param>
        /// <param name="speech">This parameter reference speech of PNJ.</param>
        public PNJ(Game gctx, Level ctx, int X, int Y, string bitMapName, string name, string speech)
            : base(gctx, X, Y, "test", name)
        {
            if (X < 0 || Y < 0)
            {
                throw new ArgumentException("You cannot create a PNJ with this coordonate");
            }

            else if (X < 16)
            {
                throw new ArgumentException("You cannot create a character with his hitbox outside the map.");
            }

            _ctx = ctx;

            if (Level.PNJ.Count != 0)
            {
                foreach (PNJ p in Level._pnj)
                {
                    if (p.positionX == X && p.positionY == Y)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
            _speech = speech;

            ctx.PNJ.Add(this);
        }

        /// <summary>
        /// This properties return a speech.
        /// </summary>
        public string Speech
        {
            get { return _speech; }
        }

        /// <summary>
        /// This properties return the context of the level.
        /// </summary>
        public Level Level
        {
            get
            { return _ctx; }
        }

        /// <summary>
        /// This properties return PNJ's speech.
        /// </summary>
        public string Talk(PNJ pnj)
        {
            return pnj.Speech;
        }
    }
}