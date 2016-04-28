using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures
{
    public class Character
    {
        int _positionX; //Position X to find a character
        int _positionY; //Position Y to find a character
        string _bitMapName; //To search the apparence of a character
        string _name; //Name of character

        public Character(int X, int Y, string bitMapName, string name)
        {
            _positionX = X;
            _positionY = Y;
            _bitMapName = bitMapName;
            _name = name;
        }

        public int positionX
        {
            get { return _positionX; }
            set { _positionX = value; }
        }

        public int positionY
        {
            get { return _positionY; }
            set { _positionY = value; }
        }

        public string BitMapName
        {
            get { return _bitMapName; }
            set { _bitMapName = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
