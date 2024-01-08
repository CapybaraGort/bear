using UnityEngine;

public class InitializationOrber : MonoBehaviour
{
    [SerializeField] private MainMenu menu;
    [SerializeField] private ObstacleSpawner spawner;
    [SerializeField] private Player player;

    private void Start()
    {
        spawner.Initialize();
        player.Initialize();
        menu.Initialize();
    }
}
