using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AngryPigs.Entitites
{
    class Pig : RenderableEntity
    {
        public override void Update(GameTime time)
        {
            // Make sure that the player does not go out of bounds
            //Position = new Vector2(MathHelper.Clamp(Position.X, 0, Kernel. Graphics.Viewport.Width - Width), 
            //    MathHelper.Clamp(Position.Y, 0, GraphicsDevice.Viewport.Height - Height));
            // git test comment
            //sdfs

        }

        public void MoveRight()
        {
            Position = new Vector2(Position.X + Velocity, Position.Y);
        }

        public void MoveLeft()
        {
            Position = new Vector2(Position.X - Velocity, Position.Y);
        }
        
    }
}
