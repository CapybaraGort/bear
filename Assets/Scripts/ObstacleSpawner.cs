using System.Collections;
using UnityEngine;
using Zenject;

public class ObstacleSpawner : MonoBehaviour, IPauseable
{
    [Inject] private PauseManager pauseManager;
    [Inject] private DiContainer diContainer;
    [SerializeField] private Obstacle obstaclePrefab;
    [SerializeField] private float spawnRate = 7.5f;
    private int obstacleMinHeight = -5;
    private int obstacleMaxHeight = 5;
    private float speedInterval = 1;
    public bool IsPaused { get; set; }

    private Coroutine spawnCoroutine;

    public void Initialize()
    {
        pauseManager.Register(this);
        StartSpawning();
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            if (IsPaused == false)
            {
                yield return new WaitForSeconds(spawnRate);
                SpawnSingleObstacle();
            }
        }
    }

    private void SpawnSingleObstacle()
    {
        int randomHeight = Random.Range(obstacleMinHeight, obstacleMaxHeight);
        Obstacle obs = diContainer.InstantiatePrefabForComponent<Obstacle>(
            obstaclePrefab,
            new Vector2(transform.position.x, transform.position.y + randomHeight),
            Quaternion.identity, null);
        obs.Init(speedInterval);
    }

    private void StartSpawning()
    {
        SpawnSingleObstacle();
        spawnCoroutine ??= StartCoroutine(SpawnObstacles());
    }
}