using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.HistoryTreasures
{
    public class Theme
    {
        readonly string _name;
        bool _isFinish;
        readonly List<Level> _levels;
        Game _ctx;
        MainCharacter _mainCharacter;

        /// <summary>
        /// This constructor create a theme.
        /// </summary>
        /// <param name="ctx">This parameter reference theme contains in game.</param>
        /// <param name="name">This parameter reference name of level.</param>
        public Theme(Game ctx, string name)
        {
            for (int i = 0; i < ctx.Themes.Count; i++)
            {
                if (ctx.Themes[i].Name == name)
                {
                    throw new InvalidOperationException("You cannot create two themes with same name");
                }
            }
            _ctx = ctx;
            _name = name;
            _isFinish = false;
            _levels = new List<Level>();
            ctx.Themes.Add(this);
        }

        /// <summary>
        /// This property returns the theme name.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// This property returns if a level is finish.
        /// </summary>
        public bool IsFinish
        {
            get { return _isFinish; }
            set { _isFinish = value; }
        }

        /// <summary>
        /// This property returns the context of the game.
        /// </summary>
        public Game Game
        {
            get { return _ctx; }
            set { _ctx = value; }
        }

        /// <summary>
        /// Gets the main character.
        /// </summary>
        /// <value>
        /// The main character.
        /// </value>
        public MainCharacter MainCharacter
        {
            get { return _mainCharacter; }
        }

        /// <summary>
        /// Gets the level list.
        /// </summary>
        /// <value>
        /// The levels.
        /// </value>
        public List<Level> Levels
        {
            get { return _levels; }
        }

        /// <summary>
        /// This method serve to create a level.
        /// </summary>
        /// <param name="name">This parameter define name of Level.</param>
        public Level CreateLevel(string name)
        {
            Level l = new Level(this, "Level");
            _levels.Add(l);
            return l;
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