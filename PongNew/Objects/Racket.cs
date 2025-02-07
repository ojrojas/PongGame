namespace Pong.PongNew.Objects;

public class Racket : BaseObject
{
    private readonly int _racketId;
    public override float Height => 200f;
    public override float Width => 20f;
    public override string Name => $"Racket{_racketId}";

    public Racket(int racketId)
    {
        _racketId = racketId;
        AddBoundingBox(new(Position, Width, Height));
    }
}