using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AngryPigs.EntityManagement;

namespace AngryPigs.GameEntitites
{
    class Pig : X2DEntity
    {
        public override void Update(GameTime time)
        {
            // Make sure that the player does not go out of bounds
            //Position = new Vector2(MathHelper.Clamp(Position.X, 0, Kernel. Graphics.Viewport.Width - Width), 
            //    MathHelper.Clamp(Position.Y, 0, GraphicsDevice.Viewport.Height - Height));


        }

        public void MoveRight()
        {
            Position = new Vector3(Position.X + Velocity.X, Position.Y,0);
        }

        public void MoveLeft()
        {
            Position = new Vector3(Position.X - Velocity.X, Position.Y,0);
        }
        
    }
}
