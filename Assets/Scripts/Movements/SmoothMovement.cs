using UnityEngine;

public class SmoothMovement : Movement
{
    public SmoothMovement(Transform transform, MovementLimiter limiter) : base(transform, limiter)
    {
        limiter.ChangeLimit(limiter.Limit.SmoothLimit);
    }

    public override void MovementImplementation()
    {
        if (Input.anyKey)
        {
            Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (IsOutLimit(Direction) == false)
            {
                Transform.Translate(Direction * Time.deltaTime * 3);

            }
        }
    }
}