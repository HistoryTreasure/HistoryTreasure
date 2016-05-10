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
        public Level(Theme ctx, MainCharacter mC, string name)
        {
            _ctx = ctx;
            _mainCharacter = mC;
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

        public string InteractionWithPNJ(KeyEnum key)
        {
            string _talk = "";
            for(int i = 0; i < _pnj.Count; i++)
            {

                if(((_mainCharacter.HitBox.xA - _pnj[i].HitBox.xA > 32) || (_mainCharacter.HitBox.xA - _pnj[i].HitBox.xA < 33)) 
                    || ((_pnj[i].HitBox.xA - _mainCharacter.HitBox.xA > 32) || (_pnj[i].HitBox.xA - _mainCharacter.HitBox.xA < 33))
                    && ((_pnj[i].HitBox.yA - _mainCharacter.HitBox.yA > 32) || (_pnj[i].HitBox.yA - _mainCharacter.HitBox.yA < 33)) 
                    || ((_mainCharacter.HitBox.yA - _pnj[i].HitBox.yA > 32) || (_mainCharacter.HitBox.yA - _pnj[i].HitBox.yA < 33)))
                {
                    key = KeyEnum.action;
                    _talk = _pnj[i].Speech;
                }
                else
                {
                    break;
                }
            }
            return _talk;
        }
    }
}