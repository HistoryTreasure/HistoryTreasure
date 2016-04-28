using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.HistoryTreasures
{
    class MainCharacter : Character
    {
        public MainCharacter(int X, int Y, string bitMapName, string name)
            : base (0, 0, "test", name)
        {
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