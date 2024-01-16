using UnityEngine;

public class InitializationOrber : MonoBehaviour
{
    [SerializeField] private MainMenu menu;
    [SerializeField] private ObstacleSpawner spawner;
    [SerializeField] private Player player;
    [SerializeField] private EventManager eventManager;
    [SerializeField] private CloudSpawner cloudSpawner;
    [SerializeField] private MeteoritSpawner meteoritSpawner;

    private void Start()
    {
        spawner.Initialize();
        player.Initialize();
        cloudSpawner.Initialize();
        meteoritSpawner.Initialize();
        menu.Initialize();
        eventManager.Initialize();
    }
}
