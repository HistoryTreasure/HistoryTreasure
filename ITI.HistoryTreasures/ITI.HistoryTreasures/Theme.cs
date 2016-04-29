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

        public Theme(Game ctx, string name)
            
        {
            _ctx = ctx;
            _name = name;
            _isFinish = false;
            _levels = new List<Level>();
        }

        public string Name
        {
            get { return _name; }
        }

        public bool isFinish
        {
            get { return _isFinish; }
        }

        public Game Game
        {
            get { return _ctx; }
            set { _ctx = value; }
        }
    }
}