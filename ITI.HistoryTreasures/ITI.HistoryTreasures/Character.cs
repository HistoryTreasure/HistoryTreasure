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

        /// <summary>
        /// This constructor allow to create a Character
        /// </summary>
        /// <param name="ctx">This parameter reference character contains in game.</param>
        /// <param name="X">This parameter reference horizontal position.</param>
        /// <param name="Y">This parameter reference vertical position.</param>
        /// <param name="bitMapName">This parameter reference appaerance of Character.</param>
        /// <param name="name">This parameter reference name of Character.</param>
        public Character(Game ctx, int X, int Y, string bitMapName, string name)
        {
            _ctx = ctx;
            _positionX = X;
            _positionY = Y;
            _bitMapName = bitMapName;
            _name = name;
        }

        /// <summary>
        /// This properties return horizontal position.
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
        /// This properties return vertical position.
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
        /// This properties return name.
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
    }
}
