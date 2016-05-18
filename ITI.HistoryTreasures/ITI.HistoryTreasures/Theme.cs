using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.HistoryTreasures
{
    public class Theme
    {
        string _name;
        bool _isFinish;
        public List<Level> _levels;
        Game _ctx;

        /// <summary>
        /// This constructor create a theme.
        /// </summary>
        /// <param name="ctx">This parameter reference theme contains in game.</param>
        /// <param name="name">This parameter reference name of level.</param>
        public Theme(Game ctx, string name)
        {
            _ctx = ctx;
            _name = name;
            _isFinish = false;
            _levels = new List<Level>();
        }

        /// <summary>
        /// This properties return the theme name.
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
        /// This properties return the context of the game.
        /// </summary>
        public Game Game
        {
            get { return _ctx; }
            set { _ctx = value; }
        }

        /// <summary>
        /// This properties return list of levels.
        /// </summary>
        public List<Level> Levels
        {
            get { return _levels; }
        }

        /// <summary>
        /// This method served to verify if a theme is completed, to complete one theme we have to complete all levels contained in this theme.
        /// </summary>
        public void FinishTheme()
        {
            bool test = true;
            foreach (Level l in _levels)
            {
                if (l.IsFinish != true)
                {
                    test = false;
                    break;
                }
                else
                    continue;
            }

            if(test != true)
                return;
            IsFinish = true;
        }
    }
}