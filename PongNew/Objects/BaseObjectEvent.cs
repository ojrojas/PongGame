namespace Pong.PongNew.Objects;

public class BaseObjectEvent : IBaseObjectEvent
{
    public class ObjectHitBy(string strikeObject) : BaseObjectEvent
    {
        public string HitBy { get; private set; } = strikeObject;
    }
}