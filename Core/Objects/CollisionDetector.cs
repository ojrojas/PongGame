namespace Pong.Core.Objects;

public class CollisionDetector<B, A>(IEnumerable<B> passiveObjects)
where B : BaseObject
where A : BaseObject
{
    private IEnumerable<B> _passiveObjects = passiveObjects;

    public void DetectCollisions(A activeObject, Action<B, A> collisionHandler)
    {
        foreach (var passiveObject in _passiveObjects)
        {
            if (DetectCollision(passiveObject, activeObject))
            {
                collisionHandler(passiveObject, activeObject);
            }
        }
    }

    public void DetectCollisions(IEnumerable<A> activeObjects, Action<B, A> collisionHandler)
    {
        foreach (var passiveObject in _passiveObjects)
        {
            var copiedList = new List<A>();
            foreach (var activeObject in activeObjects)
            {
                copiedList.Add(activeObject);
            }

            foreach (var activeObject in copiedList)
            {
                if (DetectCollision(passiveObject, activeObject))
                {
                    collisionHandler(passiveObject, activeObject);
                }
            }
        }
    }

    private bool DetectCollision(B passiveObject, A activeObject)
    {
        foreach (var passiveBB in passiveObject.BoundingBoxes)
        {
            foreach (var activeBB in activeObject.BoundingBoxes)
            {
                if (passiveBB.CollidesWith(activeBB))
                {
                    return true;
                }
            }
        }

        return false;
    }
}