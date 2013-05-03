using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AngryPigs.EntityManagement
{
    public abstract class X2DEntity : Entity
    {
        // Image representing the Entity
        private Texture2D mTexture;
        // State of the Entity
        private bool mActive;

       
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


        // Initialise method extended
        public void Initialise(int pUID, String pEntityName, Vector3 pWorldPosition, Texture2D pSpriteTexture, Vector3 pVelocity)
        {
            base.Initialise(pUID, pEntityName, pWorldPosition);
            Texture = pSpriteTexture;
            Velocity = pVelocity;
            Accelleration = new Vector3(0,0,0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Vector2Position, null, Color.White, 0f,
            new Vector2(Width / 2, Height / 2), 1f, SpriteEffects.None, 0f);
        }


    }
}
