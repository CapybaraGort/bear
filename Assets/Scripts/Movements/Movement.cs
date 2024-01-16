using UnityEngine;

public abstract class Movement
{
    public virtual Vector2 Direction { get; protected set; }
    protected virtual Transform Transform { get; set; }
    protected virtual MovementLimiter Limiter { get; set; }

    public Movement(Transform transform, MovementLimiter limiter)
    {
        Transform = transform;
        Limiter = limiter;
    }

    protected bool IsOutLimit(Vector2 dir)
    {
        return (Transform.position.x + dir.x > Limiter.MaxX) ||
        (Transform.position.y + dir.y > Limiter.MaxY) ||
            (Transform.position.x + dir.x < -Limiter.MaxX) ||
            (Transform.position.y + dir.y < -Limiter.MaxY);
    }

    public virtual void MovementImplementation()
    {

    }
}