using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures
{
    public abstract class Character
    {
        int _positionX; //Position X to find a character
        int _positionY; //Position Y to find a character
        string _bitMapName; //To search the apparence of a character
        string _name; //Name of character
        Game _ctx; //Game context
        Rectangle _hitBox;

        /// <summary>
        /// This constructor allow to create a Character
        /// </summary>
        /// <param name="ctx">This parameter reference character contains in game.</param>
        /// <param name="X">This parameter reference horizontal position with an int.</param>
        /// <param name="Y">This parameter reference vertical position with an int.</param>
        /// <param name="bitMapName">This parameter reference appaerance of Character.</param>
        /// <param name="name">This parameter reference name of Character.</param>
        public Character(Game ctx, int X, int Y, string bitMapName, string name)
        {
            _ctx = ctx;
            _positionX = X;
            _positionY = Y;
            _bitMapName = bitMapName;
            _name = name;
            _hitBox = new Rectangle(this, positionX -16, positionY, positionX + 16, positionY, positionX + 16, positionY - 16, positionX -16, positionY - 16);
        }

        /// <summary>
        /// This properties return horizontal position with an int.
        /// </summary>
        public int positionX
        {
            get { return _positionX; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("You cannot move outside the map");
                }
   
                    _positionX = value;      
            }
        }

        /// <summary>
        /// This properties return vertical position with an int.
        /// </summary>
        public int positionY
        {
            get { return _positionY; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("You cannot move outside the map");
                }

                _positionY = value;
            }
        }

        /// <summary>
        /// This properties return appaerance of Character.
        /// </summary>
        public string BitMapName
        {
            get { return _bitMapName; }
            set { _bitMapName = value; }
        }

        /// <summary>
        /// This properties return the name of the character.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// This properties return game context.
        /// </summary>
        public Game Game
        {
            get { return _ctx; }
        }

        public Rectangle HitBox
        {
            get { return _hitBox; }
        }
    }
}
