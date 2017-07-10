using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CastleDefence
{
    public abstract class Projectile
    {

        public Projectile(Vector2 startPosition, Vector2 targetPosition)
        {
            this.position = startPosition;
            this.velocity = new Velocity { X = 0, Y = 0 };

            double theta;
            theta = Math.Atan((targetPosition.X - Position.X) / (targetPosition.Y - Position.Y));
            if (targetPosition.X < Position.X)
            {
                theta = (Math.PI / 2) - theta;
            }
            
            velocity.X = Math.Sin(theta) * this.Speed;
            velocity.Y = (Math.Cos(theta) * this.Speed);
        }

        #region private properties
        protected Velocity velocity;
        protected Vector2 position;
        protected Texture2D texture;
        #endregion

        #region public properties
        public Vector2 Position 
        {
            get { return position; }
        }

        public Texture2D Texture
        {
            get { return texture; }
        }
       
        public Velocity Velocity 
        {
            get
            {
                return velocity;   
            }
        }

        public virtual double Speed
        {
            get;
            set;
        }
        #endregion

        #region public methods
        public void Move()
        {
            this.position.X += (float)velocity.X;
            this.position.Y += (float)velocity.Y;
        }
        #endregion

    }
}
