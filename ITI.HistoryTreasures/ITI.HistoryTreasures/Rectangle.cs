using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures
{
    public class Rectangle
    {
        int _a;
        int _b;
        int _c;
        int _d;

        public Rectangle(int a, int b, int c, int d)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
        }

        public int A
        {
            get { return _a; }
            set { _a = value; }
        }

        public int B
        {
            get { return _b; }
            set { _b = value; }
        }

        public int C
        {
            get { return _c; }
            set { _c = value; }
        }

        public int D
        {
            get { return _d; }
            set { _d = value; }
        }
    }
}
