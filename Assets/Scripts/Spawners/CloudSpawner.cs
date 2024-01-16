using UnityEngine;

public class CloudSpawner : Spawner
{
    [SerializeField] private Sprite[] clouds;

    protected override void SpawnObject()
    {
        float randomHeight = Random.Range(spawnMinDiopazone, spawnMaxDiopazone);
        float randomSpeed = Random.Range(1, 3);

        Cloud cloud = diContainer.InstantiatePrefabForComponent<Cloud>(
            objectPrefab,
            new Vector2(transform.position.x, transform.position.y + randomHeight),
            Quaternion.identity, null);

        cloud.Init(randomSpeed, clouds[Random.Range(0, clouds.Length)]);
    }
}
