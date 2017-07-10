using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CastleDefence.Projectiles
{
    public class CannonBall : Projectile
    {
        public CannonBall(Vector2 startPosition, Vector2 targetPosition, ContentManager content): base ( startPosition,  targetPosition)
        {
            this.texture = content.Load<Texture2D>("cannonball");
        }
        public override double Speed
        {
            get
            {
                return 5;
            }
        }
    }
}
