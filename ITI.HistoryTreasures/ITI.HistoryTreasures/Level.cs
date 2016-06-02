﻿using System;
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
            _mainCharacter = CreateMain(ctx,16,16, CharacterEnum.MCFACE, "Judd" );
            _pnjs = new List<PNJ>();
            _pnj = CreatePNJ(Theme.Game, 16, 128, CharacterEnum.GUARDFACE, "Hawke", "Hello");
            _mCtx = new Map(this, 10, 10);
            _clues = new List<Clue>();
            //_clue = 
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
            _pnjs.Add(p);
            return p;
        }

        public MainCharacter CreateMain(Theme ctx, int x, int y, CharacterEnum bitMapName, string name)
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

        public string InteractionWithPNJ(KeyEnum key)
        {
            string _talk = "";
            for(int i = 0; i < _pnjs.Count; i++)
            {

                if(((_mainCharacter.HitBox.xA - _pnjs[i].HitBox.xA > 32) || (_mainCharacter.HitBox.xA - _pnjs[i].HitBox.xA < 33)) 
                    || ((_pnjs[i].HitBox.xA - _mainCharacter.HitBox.xA > 32) || (_pnjs[i].HitBox.xA - _mainCharacter.HitBox.xA < 33))
                    && ((_pnjs[i].HitBox.yA - _mainCharacter.HitBox.yA > 32) || (_pnjs[i].HitBox.yA - _mainCharacter.HitBox.yA < 33)) 
                    || ((_mainCharacter.HitBox.yA - _pnjs[i].HitBox.yA > 32) || (_mainCharacter.HitBox.yA - _pnjs[i].HitBox.yA < 33)))
                {
                    key = KeyEnum.action;
                    _talk = _pnjs[i].Speech;
                }
                else
                {
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

        /*public string InteractionsWithClue(KeyEnum key)
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
                }

                else
                {
                    break;
                }
            }

            return _speech;
        }*/
    }
}