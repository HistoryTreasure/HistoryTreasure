using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.HistoryTreasures
{
    public class MainCharacter : Character
    {
        int _speed;

        public MainCharacter(Game ctx, int X, int Y, string bitMapName, string name)
            : base(ctx, X, Y, bitMapName, name)
        {
            _speed = 1;
            if (X < 0 || Y < 0)
            {
                throw new ArgumentException("You cannot create character to this coordonate");
            }
        }

        public int Speed
        {
            get { return _speed; }
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
    }
}