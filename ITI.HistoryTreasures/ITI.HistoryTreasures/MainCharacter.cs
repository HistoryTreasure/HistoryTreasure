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
        
        public MainCharacter(Game ctx, int X, int Y, string bitMapName, string name)
            : base(ctx, X, Y, bitMapName, name)
        {
            _speed = 1;
            _life = 3;
            if (X < 0 || Y < 0)
            {
                throw new ArgumentException("You cannot create character to this coordonate");
            }
        }

        public int Speed
        {
            get { return _speed; }
        }

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

        public void Movement(KeyEnum key)
        {
            if (key == KeyEnum.up)
                this.positionY = positionY + Speed;
            else if (key == KeyEnum.down)
                this.positionY = positionY - Speed;
            else if (key == KeyEnum.right)
                this.positionX = positionX + Speed;
            else if (key == KeyEnum.left)
                this.positionX = positionX - Speed;
        }

        /*public void Interactions(KeyEnum key)
        {
            if (key == KeyEnum.action)
            {
                if ()
                {
                    
                }
            }
        }*/
    }
}