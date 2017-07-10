using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using CastleDefence.Projectiles;

namespace CastleDefence
{
    class Towers
    {
        #region public consts
        public const int wallCost = 2;
        public const int wallRecharge = 60;
        public const int reloadPeriod = 3;
        public const int archerTowerDamage = 5;
        public const int archerTowerVelocity = 9;
        public const int archerTowerRange = 5000;
        public const int archerTowerCost = 15;
        public const int archerTowerRecharge = 5;

        public const int fireTowerDamage = 65;
        public const int fireTowerVelocity = 15;
        public const int fireTowerSplash = 5;
        public const int fireTowerRange = 50;
        public const int fireTowerCost = 50;
        public const int fireTowerRecharge = 35;

        public const int mirrorTowerDamage = 15;
        public const int mirrorTowerVelocity = 4996541;
        public const int mirrorTowerRange = 800;
        public const int mirrorTowerCost = 120;
        public const int mirrorTowerRecharge = 40;

        public const int cannonTowerDamage = 85;
        public const int cannonTowerVelocity = 35;
        public const int cannonTowerSplash = 15;
        public const int cannonTowerRange = 400;
        public const int cannonTowerCost = 200;
        public const int cannonTowerrecharge = 20;

        public const int trapDamage = 800;
        public const int trapSplash = 5;
        public const int trapRange = 5;
        public const int trapTowerCost = 180;
        public const int trapTowerRecharge = 180;

        public const int magicTowerDamage = 100;
        public const int magicTowerVelocity = 100;
        public const int magicTowerSplash = 20;
        public const int magicTowerRange = 300;
        public const int magicTowerCost = 200;
        public const int magicTowerRecharge = 20;

        public const int catapultTowerDamage = 40;
        public const int catapultTowerVelocity = 60;
        public const int catapultTowerSplash = 10;
        public const int catapultTowerRange = 300;
        public const int catapultTowerCost = 100;
        public const int catapultTowerRecharge = 10;

        #endregion

        #region private properties
        private DateTime ReloadTime = DateTime.Now;
        #endregion

        #region public methods
        public Projectile Shoot(Vector2 targetPosition, ContentManager content)
        {
            if (!IsReloading)
            {
                ReloadTime = DateTime.Now.AddSeconds(reloadPeriod);
                return new Arrow(this.towerPosition, targetPosition, content);
            }
            else
            {
                throw new InvalidOperationException("still reloading");
            }
        }
        #endregion

        #region public properties

        public float X
        {
            get
            {
                return TowerPosition.X;
            }
            set
            {
                TowerPosition.X = value;
            }
        }
        public float Y
        {
            get
            {
                return TowerPosition.Y;
            }
            set
            {
                TowerPosition.Y = value;
            }
        }

        public Vector2 towerPosition
        {
            get
            {
                return TowerPosition;
            }
        }
        private Vector2 TowerPosition = new Vector2(0, 0);

        public bool IsInRange
            (Vector2 enemyPosition)
        {
            bool isInRange = false;

            if (Math.Pow((enemyPosition.X - towerPosition.X), 2) + Math.Pow((enemyPosition.Y - towerPosition.Y), 2) <= Math.Pow(archerTowerRange, 2))
            {
                isInRange = true;
            }

            return isInRange;

        }

        public bool IsReloading
        {
            get
            {
                if (ReloadTime < DateTime.Now)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        #endregion

    }
}
