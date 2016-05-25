using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures.MapEditor
{
    public class Map
    {
        Tile[,] _tileArray;

        public Map(int width, int height)
        {
            if( width <= 1 || height <= 1)
                throw new ArgumentException("The array size cannot be negative or less than 2");
                
            _tileArray = new Tile[width,height];
        }

        public Tile[,] GetMap
        {
            get { return _tileArray; }
        }
    }
}
