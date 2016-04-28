using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.HistoryTreasures
{
    public class MainCharacter : Character
    {
        int _speed;

        public MainCharacter(int X, int Y, string bitMapName, string name)
            : base (0, 0, "test", name)
        {
            _speed = 1;
        }

        public int Speed
        {
            get { return _speed; }
        }

        public void Movement()
        {
            throw new NotImplementedException();
        }

        internal Game Game
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