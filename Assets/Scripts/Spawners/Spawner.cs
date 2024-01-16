using UnityEngine;
using Zenject;

public class Spawner : MonoBehaviour, IPauseable
{
    [Inject] protected DiContainer diContainer { get; private set; }
    [Inject] private PauseManager pauseManager;
    public bool IsPaused { get; set; }
    [field: SerializeField] protected GameObject objectPrefab { get; private set; }
    [field: SerializeField] protected float spawnMinDiopazone { get; private set; } = -5;
    [field: SerializeField] protected float spawnMaxDiopazone { get; private set; } = 5;
    [field: SerializeField] protected bool isHorizontalSpawn = false;
    [SerializeField] protected float minSpawnRate, maxSpawnRate;
    protected float spawnRate;
    protected float currentTime;
    protected bool randomSpawnRate = true;

    public void Initialize()
    {
        pauseManager.Register(this);
        spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
        OnInit();
    }
    
    protected virtual void PauseRequirement()
    {
        if (IsPaused)
            return;
    }

    private void Update()
    {
        PauseRequirement();

        if (currentTime < spawnRate)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            if(randomSpawnRate)
                spawnRate = Random.Range(minSpawnRate, maxSpawnRate);

            currentTime = 0;
            SpawnObject();
        }
        OnUpdate();
    }

    protected virtual void OnUpdate()
    {

    }
    protected virtual void OnInit()
    {

    }

    protected virtual void SpawnObject()
    {
        float randomDiopazone = Random.Range(spawnMinDiopazone, spawnMaxDiopazone);
        Vector2 vector = isHorizontalSpawn ? new Vector2(transform.position.x + randomDiopazone, transform.position.y) : new Vector2(transform.position.x, transform.position.y + randomDiopazone);
        var obj = diContainer.InstantiatePrefab(objectPrefab, 
            vector, 
            Quaternion.identity, null);
    }
}