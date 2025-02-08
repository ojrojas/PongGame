namespace Pong.PongNew.Objects;
public class Dashboard : BaseObject
{
    public override string Name => "Dashboard";
    public Dashboard(float width, float height)
    {
        Width = width; Height = height;
        AddBoundingBox(new(Vector2.Zero, Width, 1));
        AddBoundingBox(new(Vector2.Zero, 1, Height));
        AddBoundingBox(new(new Vector2(0, Height), Width, 1));
        AddBoundingBox(new(new Vector2(Width, 0), 1, Height));
    }
}