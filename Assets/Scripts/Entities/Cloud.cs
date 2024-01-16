using UnityEngine;

public class Cloud : MonoBehaviour, IPauseable
{
    [Zenject.Inject] private PauseManager pauseManager;
    private const string DESTROY_WALL_TAG = "DestroyWall";
    private SpriteRenderer spriteRenderer;
    private float speed;
    public bool IsPaused { get; set; }

    public void Init(float speed, Sprite sprite)
    {
        this.speed = speed;
        pauseManager.Register(this);
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
    }

    private void Update()
    {
        if (IsPaused)
            return;

        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == DESTROY_WALL_TAG)
        {
            Destroy(gameObject);
        }
    }
}