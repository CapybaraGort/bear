using System;
using Zenject;

public class MeteorRainEvent : BaseEvent
{
    public override string EventName => "Метеоритный дождь";
    public override float Duration => 11;

    private MeteoritSpawner meteoritSpawner;

    public MeteorRainEvent(MeteoritSpawner spawner)
    {
        meteoritSpawner = spawner;
    }

    public override void Activate()
    {
        meteoritSpawner.SetActive(true);
    }
    public override void Deactivate()
    {
        meteoritSpawner.SetActive(false);
    }
}