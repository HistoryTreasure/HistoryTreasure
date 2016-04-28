using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.HistoryTreasures
{
    class PNJ : Character
    {
        public PNJ(int X, int Y, string bitMapName, string name)
            : base (0, 0, "test", name)
        {
        }

        public Level Level
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