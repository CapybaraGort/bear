using UnityEngine;

public class Obstacle : MonoBehaviour, IPauseable
{
    [Zenject.Inject] private PauseManager pauseManager;
    private const string DESTROY_WALL_TAG = "DestroyWall";
    private float speedInterval = 1;
    private float currentTime = 0;
    public bool IsPaused { get; set; }

    private void Update()
    {
        if (IsPaused == false)
        {
            if (currentTime < speedInterval)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                transform.position = new Vector2(transform.position.x - 1, transform.position.y);
                currentTime = 0;
            }
        }
    }

    public void Init(float speed)
    {
        speedInterval = speed;
        pauseManager.Register(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == DESTROY_WALL_TAG)
        {
            Destroy(gameObject);
        }
    }

}
