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
        public List<Theme> _themes;

        /// <summary>
        /// This constructor create a game and initialize our list of theme.
        /// </summary>
        public Game()
        {
            _themes = new List<Theme>();            
        }

        /// <summary>
        /// This properties return list of theme.
        /// </summary>
        public List<Theme> Themes
        {
            get { return _themes; }
        }
    }
}
