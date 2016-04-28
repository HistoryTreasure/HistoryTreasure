using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.HistoryTreasures
{
    public class PNJ : Character
    {
        string _speech;
        
        public PNJ(int X, int Y, string bitMapName, string name, string speech)
            : base (0, 0, "test", name)
        {
            _speech = speech;
        }

        public string Speech
        {
            get { return _speech; }
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