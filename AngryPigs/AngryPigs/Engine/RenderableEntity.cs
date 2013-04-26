using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AngryPigs
{
    public abstract class RenderableEntity : Entity
    {
        // Image representing the Entity
        private Texture2D mTexture;
        // State of the Entity
        private bool mActive;

        private float mVelocity;
        private float mAccelleration;

        

        public Texture2D Texture
        {
            get { return mTexture; }
            private set { mTexture = value; }
        }
        
        public bool Active
        {
            get { return mActive; }
            set { mActive = value; }
        }

        // Get the width of the Entity
        public int Width
        {
            get { return Texture.Width; }
        }

        // Get the height of the Entity
        public int Height
        {
            get { return Texture.Height; }
        }

        public float Velocity
        {
            get { return mVelocity; }
            set { mVelocity = value; }
        }

        public float Accelleration
        {
            get { return mAccelleration; }
            set { mAccelleration = value; }
        }


        // Initialise method extended
        public void Initialise(String pEntityName, Vector2 pWorldPosition, Texture2D pSpriteTexture, float pVelocity)
        {
            base.Initialise(pEntityName, pWorldPosition);
            Texture = pSpriteTexture;
            Velocity = pVelocity;
            Accelleration = 0.0f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f,
            new Vector2(Width / 2, Height / 2), 1f, SpriteEffects.None, 0f);
        }

    }
}
