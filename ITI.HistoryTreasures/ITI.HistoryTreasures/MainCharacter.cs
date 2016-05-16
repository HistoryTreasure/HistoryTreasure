using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.HistoryTreasures
{
    public class MainCharacter : Character
    {
        int _speed;
        int _life;

        /// <summary>
        /// This constructor allow to create MainCharacter.
        /// </summary>
        /// <param name="ctx">This parameter reference the MainCharacter contains in game.</param>
        /// <param name="X">This parameter reference horizontal position with an int.</param>
        /// <param name="Y">This parameter reference vertical position with an int.</param>
        /// <param name="bitMapName">This parameter reference appaerance of Character.</param>
        /// <param name="name">This parameter reference name of PNJ.</param>
        public MainCharacter(Game ctx, int X, int Y, string bitMapName, string name)
            : base(ctx, X, Y, bitMapName, name)
        {
            if (X < 0 || Y < 0)
            {
                throw new ArgumentException("You cannot create character to this coordonate");
            }
            _speed = 1;
            _life = 3;
        }

        /// <summary>
        /// This properties return a speed with an int.
        /// </summary>
        public int Speed
        {
            get { return _speed; }
        }

        /// <summary>
        /// This properties return number of life with an int.
        /// </summary>
        public int Life
        {
            get { return _life; }
            set
            {
                if (value > 3)
                {
                    throw new ArgumentException("You cannot have more than three life !");
                }

                _life = value;
            }
        }

        /// <summary>
        /// This method served to check life of MainCharacter.
        /// When MainCharacter have 0 life, we send a message : "GameOver".
        /// </summary>
        public bool GameOver()
        {
            if (Life == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// This method allow to move the MainCharacter.
        /// </summary>
        /// <param name="key"></param>
        public void Movement(KeyEnum key)
        {
            if (key == KeyEnum.up)
                positionY = positionY + Speed;
            else if (key == KeyEnum.down)
                if (positionY == 16)
                    return;
                else
                    positionY = positionY - Speed;
            else if (key == KeyEnum.right)
                positionX = positionX + Speed;
            else if (key == KeyEnum.left)
                if (positionX == 16)
                    return;
                else
                    positionX = positionX - Speed;
        }

        /// <summary>
        /// This method allow to interact with an object or a PNJ.
        /// </summary>
        /// <param name="key"></param>
        public void Interactions(KeyEnum key)
        {
            throw new NotImplementedException();
        }
    }
}