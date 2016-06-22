﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.HistoryTreasures
{
    public class MainCharacter : Character
    {
        readonly int _speed;
        int _life;
        Map _mCtx;
        readonly Level _lCtx;
        public bool _isClue;
        bool _isPNJ;

        /// <summary>
        /// This constructor allow to create MainCharacter.
        /// </summary>
        /// <param name="ctx">This parameter reference the MainCharacter contains in game.</param>
        /// <param name="X">This parameter reference horizontal position with an int.</param>
        /// <param name="Y">This parameter reference vertical position with an int.</param>
        /// <param name="bitMapName">This parameter reference appaerance of Character.</param>
        /// <param name="name">This parameter reference name of PNJ.</param>
        public MainCharacter(Game ctx, Level lCtx, int X, int Y, CharacterEnum bitMapName, string name)
            : base(ctx, X, Y, bitMapName, name)
        {
            if (X < 0 || Y < 0)
            {
                throw new ArgumentException("You cannot create character to this coordonate");
            }

            _speed = 6;
            _life = 3;
            _lCtx = lCtx;
        }
        

        /// <summary>
        /// This property returns a speed with an int.
        /// </summary>
        public int Speed
        {
            get { return _speed; }
        }

        /// <summary>
        /// </summary>
        /// <value>
        /// The l CTX.
        /// </value>
        public Level LCtx
        {
            get { return _lCtx; }
        }

        /// <summary>
        /// This property returns number of life with an int.
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
        /// </summary>
        /// <value>
        /// The m CTX.
        /// </value>
        public Map MCtx
        {
            get { return _mCtx; }
            set { _mCtx = value; }
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
            if (key == KeyEnum.down)
            {
                positionY += Speed;

                if (positionY >= (MCtx.TileArray.GetLength(0) * 32) - 32)
                {
                    positionY = (MCtx.TileArray.GetLength(0) * 32) - 32;
                }

                HitBox.UpdateHitbox(positionX, positionY);

                foreach (Hitbox hitbox in MCtx.GetHitboxes(MCtx))
                {
                    if (HitBox.Overlaps(hitbox))
                    {
                        positionY = hitbox.yA - 32;
                        HitBox.UpdateHitbox(positionX, positionY);
                    }
                }


            }
            else if (key == KeyEnum.up)
            {
                positionY -= Speed;
                HitBox.UpdateHitbox(positionX, positionY);
                foreach (Hitbox hitbox in MCtx.GetHitboxes(MCtx))
                {
                    if (HitBox.Overlaps(hitbox))
                    {
                        positionY = hitbox.yC - 16;
                        HitBox.UpdateHitbox(positionX, positionY);
                    }
                }
            }
            else if (key == KeyEnum.right)
            {
                positionX += Speed;

                if (positionX >= (MCtx.TileArray.GetLength(1) * 32) - 32)
                {
                    positionX = (MCtx.TileArray.GetLength(1) * 32) - 32;
                }

                HitBox.UpdateHitbox(positionX, positionY);
                foreach (Hitbox hitbox in MCtx.GetHitboxes(MCtx))
                {
                    if (HitBox.Overlaps(hitbox))
                    {
                        positionX = hitbox.xA - 32;
                        HitBox.UpdateHitbox(positionX, positionY);
                    }
                }
            }
            else if (key == KeyEnum.left)
            {
                positionX -= Speed;
                HitBox.UpdateHitbox(positionX, positionY);
                foreach (Hitbox hitbox in MCtx.GetHitboxes(MCtx))
                {
                    if (HitBox.Overlaps(hitbox))
                    {
                        positionX = hitbox.xC;
                        HitBox.UpdateHitbox(positionX, positionY);
                    }
                }
            }
        }

        /// <summary>
        /// Interacts the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public string Interact(KeyEnum key)
        {
            string speech = "";

            if (key == KeyEnum.action)
            {
                _isClue = false;
                speech = LCtx.InteractionWithPNJ(key);
                if (speech == "")
                {
                    _isClue = true;
                    speech = LCtx.InteractionsWithClue(key);
                }
            }
            return speech;
        }

        public bool IsClue
        {
            get { return _isClue; }
        }
        /// <summary>
        /// Talkses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public bool CanInteract(Hitbox other)
        {
            double distance = Math.Sqrt(Math.Pow(HitBox.xA - other.xA, 2) + Math.Pow(HitBox.yA - other.yA, 2));
            return distance < 40;
        }
    }
}