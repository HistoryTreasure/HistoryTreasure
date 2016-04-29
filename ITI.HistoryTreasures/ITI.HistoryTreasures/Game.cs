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

        public Game()
        {
            _themes = new List<Theme>();            
        }

        public List<Theme> Themes
        {
            get { return _themes; }
        }
    }
}
