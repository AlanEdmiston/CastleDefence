using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace CastleDefence.Projectiles
{
    public class Arrow : Projectile
    {
        public Arrow(Vector2 startPosition, Vector2 targetPosition, ContentManager content): base ( startPosition,  targetPosition)
        {
            this.texture = content.Load<Texture2D>("arrow");
        }
        public override double Speed
        {
            get
            {
                return 10;
            }
        }
    }
}
