namespace Pong.PongNew.Objects;

public class Side :BaseObject
{
    private readonly int _sideId;
    public override string Name => $"Side{_sideId}";
    public override float Height => 5f;
    public override float Width => 1023f;

    public Side(int sideId) => _sideId = sideId;
}