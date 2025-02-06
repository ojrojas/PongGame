namespace Pong.Core.Objects;

public class BaseObject
{
    public virtual string Name => "Unnamed";
    protected Vector2 _position = Vector2.One;
    public virtual float Width { get; set; }
    public virtual float Height { get; set; }
    public virtual float _speed => 0f;
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
        SDL_SetRenderDrawColor(renderer, 255, 255, 255, 0);
        var result =  SDL_RenderFillRect(renderer, &ptr);
    }
}