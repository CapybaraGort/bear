using System;
using UnityEngine;

public class Player : MonoBehaviour, IPauseable
{
    [Zenject.Inject] private PauseManager pauseManager;
    private Vector2 direction;
    private MovementLimiter limiter;
    private const string WALL_TAG = "Wall";
    public event Action OnPlayerDeath;
    public bool IsPaused { get; set; }

    [Zenject.Inject]
    private void Construct(MovementLimiter limiter)
    {
        this.limiter = limiter;
    }

    public void Initialize()
    {
        pauseManager.Register(this);
    }

    private void Update()
    {
        if (IsPaused == false)
        {
            Movement();
        }
    }

    private void Movement()
    {
        if (Input.anyKeyDown)
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");

            if (IsOutLimit(direction) == false)
            {
                transform.position = new Vector2(
                    transform.position.x + direction.x,
                    transform.position.y + direction.y);
            }
        }
    }

    private bool IsOutLimit(Vector2 dir)
    {
        return (transform.position.x + dir.x > limiter.MaxX) || 
            (transform.position.y + dir.y > limiter.MaxY) ||
            (transform.position.x + dir.x < -limiter.MaxX) ||
            (transform.position.y + dir.y < -limiter.MaxY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == WALL_TAG)
        {
            OnPlayerDeath?.Invoke();
        }
    }
}
