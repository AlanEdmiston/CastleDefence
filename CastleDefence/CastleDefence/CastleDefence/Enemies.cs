using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CastleDefence
{
    class Enemies
    {
        #region pubilc consts
        public const int PEASANT = 1;
        public const int SOLDIER = 2;
        public const int ARCHER = 3;
        public const int KNIGHT = 4;
        public const int RAM = 5;
        public const int TURTLE = 6;
        public const int CATAPULT = 7;
        public const int KING = 8;
        #endregion

        #region lifecycle
        public Enemies(int type, Texture2D texture)
        {
            this.type = type;
            this.texture = texture;
        }
        public Enemies(int type, Texture2D texture, Texture2D texture2)
        {
            this.type = type;
            this.texture = texture;
            this.texture2 = texture2;
        }
        #endregion

        #region public properties
        public DateTime SpawnTime { get; set; }
        public DateTime DeathTime { get; set; }
        public bool Move { get; set; }

        private Texture2D texture;
        public Texture2D Texture { get { return texture; } }

        private Texture2D texture2;
        public Texture2D Texture2 { get { return texture2; } }

        private int type;
        public int Type { get { return type; } }

        public float X
        {
            get
            {
                return Position.X;
            }
            set
            {
                Position.X = value;
            }
        }
        public float Y
        {
            get
            {
                return Position.Y;
            }
            set
            {
                Position.Y = value;
            }
        }

        public Vector2 position
        {
            get
            {
                return Position;
            }
        }

        #endregion

        //peasant

        public int peasantHealth { get; set; }
        public int peasantDamage = 5;
        public int peasantRange = 10;
        public int peasantSpeed = 30;

        //soldier

        public int soldierHealth { get; set; }
        public int soldierDamage = 15;
        public int soldierRange = 10;
        public int soldierSpeed = 40;

        //knight

        public int knightHealth { get; set; }
        public int knightDamage = 35;
        public int knightRange = 15;
        public int knightSpeed = 100;

        //archer

        public int archerHealth { get; set; }
        public int archertDamage = 10;
        public int archerRange = 500;
        public int archerSpeed = 50;

        //catapult

        public int catapultHealth { get; set; }
        public int catapultDamage = 150;
        public int catapultRange = 700;
        public int catapultSpeed = 15;

        //ram

        public int ramHealth { get; set; }
        public int ramDamage = 150;
        public int ramRange = 40;
        public int ramSpeed = 10;

        //turtle

        public int turtleHealth { get; set; }
        public int turtleDamage = 30;
        public int turtleRange = 20;
        public int turtleSpeed = 5;

        //king

        public int kingHealth { get; set; }
        public int kingDamage = 250;
        public int kingRange = 50;
        public int kingSpeed = 85;

        private Vector2 Position = new Vector2(0, 0);

        
    }
}
