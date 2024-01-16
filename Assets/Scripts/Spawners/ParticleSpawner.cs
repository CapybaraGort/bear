using UnityEngine;

public static class ParticleSpawner
{
    public static void SpawnParticles(GameObject gameObject, Vector2 position, Quaternion quaternion, Transform parent, float destroy = 1)
    {
        var obj = MonoBehaviour.Instantiate(gameObject, position, quaternion, parent);
        MonoBehaviour.Destroy(obj, destroy);
    }

    public static void SpawnParticles(GameObject gameObject, Vector2 position, float destroy = 1)
    {
        var obj = MonoBehaviour.Instantiate(gameObject, position, Quaternion.identity);
        MonoBehaviour.Destroy(obj, destroy);
    }
}