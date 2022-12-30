using System.Drawing;
using Voyage_Engine.Game_Engine.ComponentSystem;

namespace Voyage_Engine.Rendere_Engine.RenderedObjects
{
    public abstract class RenderObject : Component, IRenderable
    {
        protected RenderObject()
        {
            MainRenderEngine.RegisterObject(this);
        }
        
        public abstract void Render(Graphics graphics);
    }

    public interface IRenderable
    {
        void Render(Graphics graphics);
    }
}