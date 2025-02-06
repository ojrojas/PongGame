namespace Pong.PongNew.Objects;

class Ball : BaseObject
{  
    public override float _speed => 1f;
    public override string Name => "Ball";
    public override float Height => 20f;
    public override float Width => 20f;

    public void MoveLeft()
    {
        Position = new Vector2(Position.X -_speed, Position.Y);
    }

    public void MoveRight()
    {
        Position = new Vector2(Position.X + _speed, Position.Y);    
    }
}
