namespace Pong.Core.Objects;

public class BaseObject
{
    public string Name { get; set; }
    protected Vector2 _position = Vector2.One;
    public float Width { get; set; }
    public float Height { get; set; }
    protected float _angle;
    protected Vector2 _direction;

    public virtual Vector2 Position
    {
        get => _position;
        set
        {
            _position = value;
        }
    }

    public virtual unsafe void Draw(SDL_Renderer renderer)
    {
        RectangleF ptr = new(new PointF(Position), new SizeF(Width,Height));
        SDL_RenderFillRect(renderer, &ptr);
    }
}