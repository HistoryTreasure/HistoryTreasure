﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.HistoryTreasures
{
    public class PNJ : Character
    {
        readonly string _speech;
        readonly string _name;
        readonly Level _ctx;

        /// <summary>
        /// This constructor allow to create a PNJ.
        /// </summary>
        /// <param name="gctx">This parameter reference pnj contains in game.</param>
        /// <param name="ctx">This parameter reference pnj contains in level.</param>
        /// <param name="X">This parameter reference horizontal position with an int.</param>
        /// <param name="Y">This parameter reference vertical position with an int.</param>
        /// <param name="bitMapName">This parameter reference appaerance of Character.</param>
        /// <param name="name">This parameter reference name of PNJ.</param>
        /// <param name="speech">This parameter reference speech of PNJ.</param>
        public PNJ(Game gctx, Level ctx, int X, int Y, CharacterEnum bitMapName, string name, string speech)
            : base(gctx, X, Y, bitMapName, name)
        {
            if (X < 0 || Y < 0)
            {
                throw new ArgumentException("You cannot create a PNJ with this coordonate");
            }

            for (int i = 0; i < ctx.Pnjs.Count; i++)
            {
                if (ctx.Pnjs[i].Name == name)
                {
                    throw new InvalidOperationException("You cannot create two PNJ with same name");
                }

                else if (ctx.Pnjs[i].Speech == speech)
                {
                    throw new InvalidOperationException("You cannot have the same speech twice.");
                }
            }

            _ctx = ctx;
            if (Level.Pnjs.Count != 0)
            {
                foreach (PNJ p in Level.Pnjs)
                {
                    if (p.positionX == X && p.positionY == Y)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
            _speech = speech;
            _name = name;

            
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
    }
}