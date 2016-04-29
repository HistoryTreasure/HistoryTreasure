using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.HistoryTreasures
{
    public class Level
    {
        string _name;
        bool _isFinish;
        private List<PNJ> _pnj;

        public Level(string name)
        {
            _name = name;
            _isFinish = false;
        }

        public Theme Theme
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}