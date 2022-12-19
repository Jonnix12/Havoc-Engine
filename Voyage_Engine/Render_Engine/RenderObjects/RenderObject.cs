using System.Drawing;

namespace Voyage_Engine.Rendere_Engine.RenderedObjects
{
    public abstract class RenderObject : IRenderable
    {
        public RenderObject()
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