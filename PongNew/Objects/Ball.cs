namespace Pong.PongNew.Objects;

class Ball : BaseObject
{
    public override float _speed => 5f;
    public override string Name => "Ball";
    public override float Height => 20f;
    public override float Width => 20f;

    public void MoveLeft()
    {
        Position = new Vector2(Position.X - _speed, Position.Y);
        AddBoundingBox(new(Position, Width, Height));
    }

    public void MoveRight()
    {
        Position = new Vector2(Position.X + _speed, Position.Y);
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
                break;
            case "Side2":
                LogInformation("Hit by Side2");
                break;
            case "Racket1":
                LogInformation("Hit by Racket1");
                break;
            case "Racket2":
                LogInformation("Hit by Racket2");

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
