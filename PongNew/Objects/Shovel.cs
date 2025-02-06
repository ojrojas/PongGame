
namespace Pong.PongNew.Objects;
public class Shovel : BaseObject, IShovel
{
    private readonly int _shovelId;
    public override float Height => 200f;
    public override float Width => 20f;
    public override string Name => $"shovel{_shovelId}";

    public Shovel(int shovelId) => _shovelId = shovelId;

    public void Move()
    {

    }
}