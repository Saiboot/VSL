using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace VSL.Context
{
    abstract class Entity
    {
        public static List<Entity> Collection = new List<Entity>();
        public static void Destroy(Entity e) => Collection.Remove(e);

        protected Texture2D m_Img;
        protected Color m_Color = Color.White;

        protected Vector2 m_Pos;    // Position
        protected Vector2 m_Vel;    // Velocity
        protected Vector2 m_Dir;    // Direction
        protected float m_Rotation = 0;

        public bool isAlive;

        protected Entity(ContentManager manager, string texture, Vector2 pos)
        {
            isAlive = true;
            m_Pos = pos;
            m_Img = manager.Load<Texture2D>(texture);
            Collection.Add(this);
        }

        public virtual void Update(GameTime time)
        {
            if (!isAlive)
                Collection.Remove(this);
        }

        public virtual void Draw(SpriteBatch sb)
        {

        }
    }
}
