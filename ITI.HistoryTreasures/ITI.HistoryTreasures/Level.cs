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
        public List<PNJ> _pnj;
        Theme _ctx;
        MainCharacter _mainCharacter;

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
        }

        /// <summary>
        /// This properties return the name of the level.
        /// </summary>
        public string Name
        {
            get { return _name; }
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
        /// This properties return the theme of the level.
        /// </summary>
        public Theme Theme
        {
            get { return _ctx; }
        }

        /// <summary>
        /// This properties return the MainCharacter.
        /// </summary>
        public MainCharacter MainCharacter
        {
            get { return _mainCharacter; }
        }

        /*public void InteractionWithPNJ(KeyEnum key)
        {
            if ((_mainCharacter.HitBox.xA && _mainCharacter.HitBox.yA) && _pnj[0].HitBox.xA)
            {
                key = KeyEnum.action;
                _pnj[0].Talk(_pnj[0]);
            }
        }*/
    }
}