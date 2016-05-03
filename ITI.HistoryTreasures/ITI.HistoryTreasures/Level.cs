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
        /// <param name="ctx">This parameter reference level contains in theme.</param>
        /// <param name="name">This parameter reference name of level.</param>
        public Level(Theme ctx, string name)
        {
            _ctx = ctx;
            _name = name;
            _isFinish = false;
            _pnj = new List<PNJ>();
        }

        /// <summary>
        /// This properties return a name.
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
        /// This properties return the context of the theme.
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

        /// <summary>
        /// This method served to check life of MainCharacter.
        /// When MainCharacter have 0 life, we send a message : "GameOver".
        /// </summary>
        public void GameOver()
        {
            if (_mainCharacter.Life == 0)
            {
                throw new NotImplementedException();
            }
        }
    }
}