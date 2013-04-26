using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AngryPigs
{

    public abstract class Entity : IEntity
    {

        // unique name of the entity
        string mName;
        // world prosition of entity
        Vector2 mWorldPosition;


        public string Name
        {
            get { return mName; }
            private set { mName = value; }
        }


        public Vector2 Position
        {
            get { return mWorldPosition; }
            set { mWorldPosition = value; }
        }

        public void Initialise(String pEntityName, Vector2 pWorldPosition)
        {
            Name = pEntityName;
            Position = pWorldPosition;
        }

        public abstract void Update(GameTime time);
    }
}
