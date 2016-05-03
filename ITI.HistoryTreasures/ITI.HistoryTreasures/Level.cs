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

        public Level(Theme ctx, string name)
        {
            _ctx = ctx;
            _name = name;
            _isFinish = false;
            _pnj = new List<PNJ>();
        }

        public string Name
        {
            get { return _name; }
        }

        public bool IsFinish
        {
            get { return _isFinish; }
            set { _isFinish = value; }
        }

        public Theme Theme
        {
            get { return _ctx; }
        }

        public MainCharacter MainCharacter
        {
            get { return _mainCharacter; }
        }

        public void FinishLevel()
        {
            IsFinish = true;
        }

        public void GameOver()
        {
            if (_mainCharacter.Life == 0)
            {
                throw new NotImplementedException();
            }
        }
    }
}