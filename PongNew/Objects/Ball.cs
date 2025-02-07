namespace Pong.PongNew.Objects;

class Ball : BaseObject
{
    public override string Name => "Ball";
    public override float Height => 20f;
    public override float Width => 20f;
    public float _speedY { get; set; }

    public Ball()
    {
        AddBoundingBox(new(Position, Width, Height));
        Direction = new Vector2(-1, 0);
        var random = new Random();
        _speed = random.Next(0, 2) == 0 ? 4 : -4;
        _speedY = random.Next(0, 2) == 0 ? 4 : -4;
    }

    public void Move()
    {
        Position = new Vector2(Position.X + _speed, Position.Y + _speedY);
    }

    public override void OnNotify(IBaseObjectEvent eventGame)
    {
        switch (eventGame)
        {
            case BaseObjectEvent.ObjectHitBy o:
                JustHitSide(o.HitBy);
                break;
            default:
                break;
        }
    }

    private void JustHitSide(string hitbyd)
    {
        switch (hitbyd)
        {
            case "Side1":
                LogInformation("Hit by Side1");
                _speedY *= -1;
                break;
            case "Side2":
                LogInformation("Hit by Side2");
                _speedY *= -1;
                break;
            case "Racket1":
                LogInformation("Hit by Racket1");
                _speed *= -1;
                break;
            case "Racket2":
                LogInformation("Hit by Racket2");
                _speed *= -1;

                break;
            default:
                break;
        }
    }

    public enum BallDirection
    {
        Left,
        Right,
    }
}
