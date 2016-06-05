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
        /// This constructor allow to create a Rectangle. 
        /// </summary>
        /// <param name="ctx">This parameter reference rectangle contains in character.</param>
        /// <param name="xA">Coordonate X in a point A.</param>
        /// <param name="yA">Coordonate Y in a point A.</param>
        /// <param name="xB">Coordonate X in a point B.</param>
        /// <param name="yB">Coordonate Y in a point B.</param>
        /// <param name="xC">Coordonate X in a point C.</param>
        /// <param name="yC">Coordonate Y in a point C.</param>
        /// <param name="xD">Coordonate X in a point D.</param>
        /// <param name="yD">Coordonate Y in a point D.</param>
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
        /// Length of the hitbox.
        /// </summary>
        /// <returns>The length in a int</returns>
        public int Length()
        {
            return xB - xA;
        }

        /// <summary>
        /// Height of the hitbox.
        /// </summary>
        /// <returns>The Height in a int</returns>
        public int Height()
        {
            return yC - yA;
        }

        /// <summary>
        /// Updates the hitbox position.
        /// </summary>
        /// <param name="key">The key pressed.</param>
        /// <param name="Speed">The speed of the character.</param>
        public void UpdateHitbox(KeyEnum key, int Speed)
        {
            if (key == KeyEnum.right)
            {
                xA = xA + Speed;
                xB = xB + Speed;
                xC = xC + Speed;
                xD = xD + Speed;
            }
            else if (key == KeyEnum.left)
            {
                xA = xA - Speed;
                xB = xB - Speed;
                xC = xC - Speed;
                xD = xD - Speed;
            }
            else if (key == KeyEnum.up)
            {
                yA = yA - Speed;
                yB = yB - Speed;
                yC = yC - Speed;
                yD = yD - Speed;
            }
            else if (key == KeyEnum.down)
            {
                yA = yA + Speed;
                yB = yB + Speed;
                yC = yC + Speed;
                yD = yD + Speed;
            }
        }
    }
}
