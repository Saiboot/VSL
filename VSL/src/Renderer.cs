using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VSL.Graphics
{
    class Renderer
    {

        public Renderer(GraphicsDeviceManager gdm)
        {
            m_Renderer = gdm;
            m_Tx3D = new Texture3D(m_Renderer.GraphicsDevice, 20, 20, 5, false, SurfaceFormat.Rgba64);
        }

        void draw()
        {
            m_Renderer.BeginDraw();

            

            m_Renderer.EndDraw();
        }

        GraphicsDeviceManager m_Renderer;
        RenderTarget3D renderer;
        Texture3D m_Tx3D;
    }
}
