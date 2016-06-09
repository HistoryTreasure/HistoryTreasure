using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures
{
    public class Hitbox
    {
        int _xA;
        int _yA;
        int _xB;
        int _yB;
        int _xC;
        int _yC;
        int _xD;
        int _yD;
        
        /// <summary>
        /// This constructor allow to create a Hitbox. 
        /// </summary>
        /// <param name="xA">Coordonate X of the point A.</param>
        /// <param name="yA">Coordonate Y of the point A.</param>
        /// <param name="xC">Coordonate X of the point C.</param>
        /// <param name="yC">Coordonate Y of the point C.</param>
        public Hitbox(int xA, int yA, int xC, int yC)
        {
            _xA = xA;
            _yA = yA;
            _xB = xC;
            _yB = yA;
            _xC = xC;
            _yC = yC;
            _xD = xA;
            _yD = yC;
        }

        /// <summary>
        /// This property returns coordonate of our Rectangle.
        /// </summary>
        public int xA { get { return _xA; } set { _xA = value; } }
        public int yA { get { return _yA; } set { _yA = value; } }
        public int xB { get { return _xB; } set { _xB = value; } }
        public int yB { get { return _yB; } set { _yB = value; } }
        public int xC { get { return _xC; } set { _xC = value; } }
        public int yC { get { return _yC; } set { _yC = value; } }
        public int xD { get { return _xD; } set { _xD = value; } }
        public int yD { get { return _yD; } set { _yD = value; } }

        /// <summary>
        /// Check if a hitbox Overlaps another.
        /// </summary>
        /// <param name="other">The other hitbox.</param>
        /// <returns>True if the hitbox overlaps</returns>
        public bool Overlaps( Hitbox other)
        { 
            return  !(yA >= other.yC || yC <= other.yA || xA >= other.xC || xC <= other.xA);
        }
        
        /// <summary>
        /// Length of the hitbox.
        /// </summary>
        /// <returns>Return the lenght of the hitbox</returns>
        public int Length()
        {
            return xB - xA;
        }

        /// <summary>
        /// Height of the hitbox.
        /// </summary>
        /// <returns>Return the Height of the hitbox</returns>
        public int Height()
        {
            return yC - yA;
        }

        /// <summary>
        /// Updates the hitbox.
        /// </summary>
        /// <param name="posX">The X coordonate of the character.</param>
        /// <param name="posY">The Y coordonate of the character.</param>
        public void UpdateHitbox(int posX, int posY)
        {
            xA = posX;
            yA = posY + 16;
            xC = posX + 32;
            yC = yA + 16;
        }
    }
}
