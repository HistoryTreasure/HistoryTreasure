using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ITI.HistoryTreasures
{
    public class Game
    {
        readonly List<Theme> _themes;

        /// <summary>
        /// This constructor create a game and initialize our list of theme.
        /// </summary>
        public Game()
        {
            _themes = new List<Theme>();
            Themes.Add(CreateTheme("1"));
        }

        /// <summary>
        /// This method serve to create a Theme. 
        /// </summary>
        /// <param name="name">This parameter define name of theme.</param>
        public Theme CreateTheme(string name)
        {
            Theme t = new Theme(this, name);
            Themes.Add(t);
            return t;
        }

        /// <summary>
        /// This properties return list of theme.
        /// </summary>
        public List<Theme> Themes
        {
            get { return _themes; }
        }

        public Level Check()
        {
            foreach (Theme t in Themes)
            {
                if (t.IsFinish)
                {
                    continue;
                }
                else
                {
                    foreach (Level l in t.Levels)
                    {
                        if (l.IsFinish)
                        {
                            continue;
                        }
                        else
                        {
                            return l;
                        }
                    }
                }
            }
            throw new InvalidOperationException("Not possible");
        }
    }
}

