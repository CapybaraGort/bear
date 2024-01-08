using Zenject;
using UnityEngine;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private MovementLimiter limiter;
    [SerializeField] private PauseManager pauseManager;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Player player;

    public override void InstallBindings()
    {
        Container.Bind<MovementLimiter>().FromInstance(limiter).AsSingle();
        Container.Bind<GameManager>().FromInstance(gameManager).AsSingle();
        Container.Bind<PauseManager>().FromInstance(pauseManager).AsSingle();
        Container.Bind<Player>().FromInstance(player).AsSingle();
    }
}