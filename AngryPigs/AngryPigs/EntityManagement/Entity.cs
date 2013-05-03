using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AngryPigs.EntityManagement
{

    public abstract class Entity : IEntity
    {
        // unique ID of entity
        private int mID;
        // unique name of the entity
        private string mName;
        // world prosition of entity
        private Vector3 mWorldPosition;
        private Vector3 mOrientation;
        private Vector3 mVelocity;
        private Vector3 mAccelleration;


        public int ID
        {
            get { return mID; }
        }

        public string Name
        {
            get { return mName; }
        }

        public Vector3 Position
        {
            get { return mWorldPosition; }
            set { mWorldPosition = value; }       //private? as considering object should have sole control over its position, if external arbitrary repositioning required set up via specific method in that class?
        }

        // Return vector2 position X,Y coords for drawsprite method
        public Vector2 Vector2Position
        {
            get { return new Vector2(mWorldPosition.X, mWorldPosition.Y); }
        }

        public Vector3 Orientation
        {
            get { return mOrientation; }
            set { mOrientation = value; mOrientation.Normalize(); }
        }

        public Vector3 Velocity
        {
            get { return mVelocity; }
            set { mVelocity = value; }
        }

        public Vector3 Accelleration
        {
            get { return mAccelleration; }
            set { mAccelleration = value; }
        }

        public void Initialise(int pUID, String pEntityName, Vector3 pWorldPosition)
        {
            pUID = mID;
            mName = pEntityName;
            mWorldPosition = pWorldPosition;
        }

        public abstract void Update(GameTime time);
    }
}
