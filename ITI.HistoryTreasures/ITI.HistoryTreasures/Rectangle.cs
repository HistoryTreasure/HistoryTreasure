using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures
{
    public class Rectangle
    {
        Character _ctx;
        int _xA;
        int _yA;
        int _xB;
        int _yB;
        int _xC;
        int _yC;
        int _xD;
        int _yD;

        public Rectangle(Character ctx,int xA, int yA, int xB, int yB, int xC, int yC, int xD, int yD)
        {
            _ctx = ctx;
            _xA = xA;
            _yA = yA;
            _xB = xB;
            _yB = yB;
            _xC = xC;
            _yC = yC;
            _xD = xD;
            _yD = yD;
        }

        public Character rectangleCtx { get { return _ctx; } }

        public int xA { get { return _xA; } set { _xA = value; } }
        public int yA { get { return _yA; } set { _yA = value; } }
        public int xB { get { return _xB; } set { _xB = value; } }
        public int yB { get { return _yB; } set { _yB = value; } }
        public int xC { get { return _xB; } set { _xB = value; } }
        public int yC { get { return _yC; } set { _yC = value; } }
        public int xD { get { return _xB; } set { _xB = value; } }
        public int yD { get { return _yD; } set { _yD = value; } }

    }
}
