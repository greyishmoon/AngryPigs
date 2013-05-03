using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AngryPigs.EntityManagement
{
    interface IEntity
    {
        int ID { get; }
        void Initialise(int pUID, string pEntityName, Microsoft.Xna.Framework.Vector3 pWorldPosition);
        string Name { get; }
        Microsoft.Xna.Framework.Vector3 Orientation { get; set; }
        Microsoft.Xna.Framework.Vector3 Position { get; }
        void Update(Microsoft.Xna.Framework.GameTime time);
    }
}
