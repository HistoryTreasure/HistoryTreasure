using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.HistoryTreasures
{
    public class Theme
    {
        List<Level> _level;
        string _name;
        bool _isFinish;
        private List<Level> _levels;

        public Theme(string name)
            : base()
        {
            _name = name;
            _isFinish = false;
            _level = new List<Level>();
            Level level = new Level("Try");
            _level.Add(level);
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