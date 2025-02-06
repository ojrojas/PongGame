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
    protected IList<BoundingBox> _boundingBoxes = [];

    public event EventHandler<IBaseObjectEvent> OnObjectReported;
    public virtual void OnNotify(IBaseObjectEvent eventGame){}
    
    public void SendEvent(IBaseObjectEvent eventGame)
    {
        OnObjectReported?.Invoke(this, eventGame);
    }

    public virtual Vector2 Position
    {
        get => _position;
        set
        {
            var deltaX = value.X - _position.X;
            var deltaY = value.Y - _position.Y;
            _position = value;

            foreach (var bb in _boundingBoxes)
            {
                bb.Position = new Vector2(bb.Position.X + deltaX, bb.Position.Y + deltaY);
            }
        }
    }

    public void AddBoundingBox(BoundingBox bb)
    {
        _boundingBoxes.Add(bb);
    }

    public IList<BoundingBox> BoundingBoxes
    {
        get
        {
            return _boundingBoxes;
        }
    }

    public virtual unsafe void Draw(SDL_Renderer renderer)
    {
        RectangleF ptr = new(new PointF(Position), new SizeF(Width, Height));
        SDL_SetRenderDrawColor(renderer, 255, 255, 255, 0);
        var result = SDL_RenderFillRect(renderer, &ptr);
    }
}