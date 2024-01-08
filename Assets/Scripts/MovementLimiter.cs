using UnityEngine;

public class MovementLimiter : MonoBehaviour
{
    [SerializeField] private Vector2 limit;
    public int MaxX
    {
        get => (int)limit.x / 2;
    }
    public int MaxY
    {
        get => (int)limit.y / 2;
    }

    private void Start()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, limit);
    }
}
