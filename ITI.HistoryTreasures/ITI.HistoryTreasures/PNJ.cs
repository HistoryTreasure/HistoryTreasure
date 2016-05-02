using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.HistoryTreasures
{
    public class PNJ : Character
    {
        string _speech;
        readonly Level _ctx;

        public PNJ(Game gctx, Level ctx, int X, int Y, string bitMapName, string name, string speech)
            : base(gctx, 0, 0, "test", name)
        {
            _ctx = ctx;
            _speech = speech;
            if (X < 0 || Y < 0)
            {
                throw new ArgumentException("You cannot create a PNJ with this coordonate");
            }
        }

        public string Speech
        {
            get { return _speech; }
        }

        public Level Level
        {
            get
            { return _ctx; }
        }
    }
}