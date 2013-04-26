using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AngryPigs
{
    interface IEntity
    {
        // unique name of the entity
        string Name { get;}
        // world prosition of entity
        Microsoft.Xna.Framework.Vector2 Position { get; set; }

        void Initialise(String pEntityName, Vector2 pWorldPosition);
        void Update(GameTime time);
    }
}
