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
    class Globe : Entity
    {

        public Handle m_Handle;

        public Globe(ContentManager manager, string texture, Vector2 pos, Handle handle) : base(manager, texture, pos)
        {
            m_Handle = handle;
        }

        public override void Update(GameTime time)
        {
            base.Update(time);

            if (Vector2.Distance(m_Pos, m_Handle.End) > m_Handle.m_Length)
                m_Handle.attached = false;
            else
                m_Handle.attached = true;

            m_Handle.GetGlobePos(m_Pos);
        }


        public override void Draw(SpriteBatch sb)
        {
            if (isAlive)
            {
                sb.Begin();
                sb.Draw(m_Img, m_Pos, m_Color);
                sb.End();
            }
        }
    }

    class Handle : Entity
    {
        public float m_Length;
        bool m_Attached;
        Vector2 globe_pos;
        public float degrees;
        public Handle(ContentManager manager, string texture, Vector2 pos, float length) : base(manager, texture, pos)
        {
            m_Length = length;
        }

        public override void Draw(SpriteBatch sb)
        {
            if (isAlive && m_Attached)
            {
                sb.Begin();
                sb.Draw( m_Img, m_Pos, color: m_Color, rotation: degrees);

                degrees =  (globe_pos.Y - m_Pos.Y) / Vector2.Distance(m_Pos, globe_pos);

                
                sb.End();
            }
        }

        public void GetGlobePos(Vector2 pos)
        {
            globe_pos = pos;
        }

        public void Translate(Vector2 translation)
        {
            m_Pos += translation;
        }

        public void setPos(Vector2 pos)
        {
            m_Pos = pos;
        }

        public Vector2 End { get { return m_Pos; } }
        public bool attached { get { return m_Attached; } set { m_Attached = value; } }
    }

}
