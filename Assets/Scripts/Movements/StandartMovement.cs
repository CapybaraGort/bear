using UnityEngine;

public class StandartMovement : Movement
{
    public StandartMovement(Transform transform, MovementLimiter limiter) : base(transform, limiter)
    {
        limiter.ChangeLimit(limiter.Limit.StandartLimit);
    }

    public override void MovementImplementation()
    {
        if (Input.anyKeyDown)
        {
            Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if(IsOutLimit(Direction) == false)
            {
                Transform.position = new Vector2(
                    Transform.position.x + Direction.x,
                    Transform.position.y + Direction.y);

            }
        }
    }
}
