namespace Pong.PongNew.Objects;

public class Racket : BaseObject
{
    private readonly int _racketId;
    public override float Height => 200f;
    public override float Width => 20f;
    public override string Name => $"Racket{_racketId}";
    public override float _speed => 20f;

    public Racket(int racketId)
    {
        _racketId = racketId;
        AddBoundingBox(new(Position, Width, Height));
    }

    public void MoveUp()
    {
        Position = new Vector2(Position.X, Position.Y - _speed);

    }

    public void MoveDown()
    {
        Position = new Vector2(Position.X, Position.Y + _speed);
    }
}