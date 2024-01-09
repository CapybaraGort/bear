using System.Collections;
using UnityEngine;
using Zenject;

public class ObstacleSpawner : MonoBehaviour, IPauseable
{
    [Inject] private PauseManager pauseManager;
    [Inject] private DiContainer diContainer;
    [SerializeField] private Obstacle obstaclePrefab;
    [SerializeField] private float spawnRate = 7.5f;
    [SerializeField] private float speedInterval = 1;
    private int obstacleMinHeight = -5;
    private int obstacleMaxHeight = 5;
    public bool IsPaused { get; set; }
    private float currentTime = 0;

    public void Initialize()
    {
        pauseManager.Register(this);
        SpawnSingleObstacle();
    }

    private void Update()
    {
        if (IsPaused)
            return;

        SpawnObstacles();

        if (spawnRate > 3)
        {
            spawnRate -= Time.deltaTime / 50;
        }

        if (speedInterval > 0.45f)
        {
            speedInterval -= Time.deltaTime / 300;
        }
    }

    private void SpawnObstacles()
    {
        if (currentTime < spawnRate)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            SpawnSingleObstacle();
            currentTime = 0;
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
}