using UnityEngine;

public class MovementLimiter : MonoBehaviour
{
    [SerializeField] private Vector2 limit;
    public LimitType Limit = new LimitType();
    public float MaxX
    {
        get => limit.x / 2;
    }
    public float MaxY
    {
        get => limit.y / 2;
    }

    public void ChangeLimit(Vector2 newLimit)
    {
        limit = newLimit;
    }
    public void ChangeLimit(int addX, int addY)
    {
        limit = new Vector2(limit.x + addX, limit.y + addY);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, limit);
    }

    public class LimitType
    {
        public Vector2 StandartLimit { get; private set; } = new Vector2(18, 10);
        public Vector2 SmoothLimit { get; private set; } = new Vector2(19, 11f);
    }
}
