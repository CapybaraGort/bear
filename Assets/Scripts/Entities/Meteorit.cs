using UnityEngine;

public class Meteorit : MonoBehaviour, IPauseable
{
    [Zenject.Inject] private PauseManager m_PauseManager;
    [SerializeField] private Transform child;
    private float randomSpeed;
    private int randomRotationSpeed;
    private const string DESTROY_WALL_TAG = "DestroyWall";
    public bool IsPaused { get; set; }

    public void Start()
    {
        m_PauseManager.Register(this);
        randomSpeed = Random.Range(1, 1.5f);
        randomRotationSpeed = Random.Range(20, 25);
    }

    private void Update()
    {
        if (IsPaused) { return; }

        transform.Translate(Vector2.down * randomSpeed * Time.deltaTime);
        child.Rotate(new Vector3(0, 0, randomRotationSpeed * Time.deltaTime));
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == DESTROY_WALL_TAG)
        {
            Destroy(gameObject);
        }
    }
}
