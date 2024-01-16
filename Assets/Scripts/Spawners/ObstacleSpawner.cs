using UnityEngine;

public class ObstacleSpawner : Spawner
{
    private float speedInverval = 1;

    protected override void OnInit()
    {
        randomSpawnRate = false;
        SpawnObject();
        spawnRate = maxSpawnRate;
    }

    protected override void OnUpdate()
    {
        if (spawnRate > 3)
        {
            spawnRate -= Time.deltaTime / 50;
        }

        if (speedInverval > 0.45f)
        {
            speedInverval -= Time.deltaTime / 300;
        }
    }

    protected override void SpawnObject()
    {
        int randomHeight = Random.Range((int)spawnMinDiopazone, (int)spawnMaxDiopazone);
        MoveableObstacle obs = diContainer.InstantiatePrefabForComponent<MoveableObstacle>(
            objectPrefab,
            new Vector2(transform.position.x, transform.position.y + randomHeight),
            Quaternion.identity, null);
        obs.Init(speedInverval);
    }
}