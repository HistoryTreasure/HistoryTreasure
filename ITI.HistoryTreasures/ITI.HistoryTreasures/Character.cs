using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.HistoryTreasures
{
    public abstract class Character
    {
        int _positionX;
        int _positionY;
        CharacterEnum _bitMapName;
        string _name;
        readonly Game _ctx;
        readonly Hitbox _hitBox;
        MainCharacter _mc;

        /// <summary>
        /// This constructor allow to create a Character.
        /// </summary>
        /// <param name="ctx">This parameter reference character contains in game.</param>
        /// <param name="X">This parameter reference horizontal position with an int.</param>
        /// <param name="Y">This parameter reference vertical position with an int.</param>
        /// <param name="bitMapName">This parameter reference appaerance of Character.</param>
        /// <param name="name">This parameter reference name of Character.</param>
        public Character(Game ctx, int X, int Y, CharacterEnum bitMapName, string name)
        {
            _ctx = ctx;
            _positionX = X;
            _positionY = Y;
            _bitMapName = bitMapName;
            _name = name;
            _hitBox = new Hitbox(positionX, positionY + 16, positionX + 32, positionY + 32, GetType());
        }

        /// <summary>
        /// This property returns horizontal position with an int.
        /// </summary>
        public int positionX
        {
            get { return _positionX; }
            set
            {
                if (value < 0)
                {
                    _positionX = 0;
                    return;
                } 
                _positionX = value;
            }
        }

        /// <summary>
        /// This property returns vertical position with an int.
        /// </summary>
        public int positionY
        {
            get { return _positionY; }
            set
            {
                if (value < 0)
                {
                    _positionY = 0;
                    return;
                }
                _positionY = value;
            }
        }

        /// <summary>
        /// Gets the name of the character bitmap.
        /// </summary>
        /// <value>
        /// The name of the character bitmap.
        /// </value>
        public CharacterEnum CharacterBitmapName
        {
            get { return _bitMapName; }
            set { _bitMapName = value; }
        }

        /// <summary>
        /// This property returns the name of the Character.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// This property returns game context.
        /// </summary>
        public Game Game
        {
            get { return _ctx; }
        }

        /// <summary>
        /// This property returns hitbox.
        /// </summary>
        public Hitbox HitBox
        {
            get { return _hitBox; }
        }


    }
}
