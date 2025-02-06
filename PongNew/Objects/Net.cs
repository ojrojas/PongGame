using System.Drawing;
using SDL3;

namespace Pong.PongNew.Objects;

public class Net : BaseObject
{
    private readonly float _heightWindow;
    private readonly int _divideLine;
    private readonly float _widthWindow;
    public override float Width => 5f;
    public override float Height => 10f;

    public IList<BaseObject> _dotteds = [];



    public Net(float heightWindow, float widthWindow, int divideLine)
    {
        _heightWindow = heightWindow;
        _divideLine = divideLine;
        _widthWindow = widthWindow;
    }

    public override unsafe void Draw(SDL_Renderer renderer)
    {
        int count = (int)_heightWindow / _divideLine;
        SDL3.SDL3.SDL_SetRenderDrawColor(renderer, 155, 155, 155, 255);
        for (int i = 0; i < _heightWindow; i += count)
        {
            RectangleF ptr = new(new PointF(_widthWindow/2, i), new SizeF(Width, Height));
            var result = SDL3.SDL3.SDL_RenderFillRect(renderer, &ptr);
        }

        base.Draw(renderer);
    }
}