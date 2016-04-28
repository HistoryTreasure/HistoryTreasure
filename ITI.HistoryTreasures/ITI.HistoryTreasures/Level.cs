using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.HistoryTreasures
{
    public class Level : Game
    {
        string _name;
        bool _isFinish;

        public Level(string name)
        {
            _name = name;
            _isFinish = false;
        }
    }
}