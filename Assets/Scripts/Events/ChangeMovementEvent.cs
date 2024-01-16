public class ChangeMovementEvent : BaseEvent
{
    public override string EventName => "Гладкое передвижение";
    public override float Duration => 12;
    private Player player;
    private MovementLimiter limiter;
    public ChangeMovementEvent(Player player, MovementLimiter limiter)
    {
        this.player = player;
        this.limiter = limiter;

    }
    public override void Activate()
    {
        player.ChangeMovement(new SmoothMovement(player.transform, limiter));
    }

    public override void Deactivate()
    {
        player.ChangeMovement(new StandartMovement(player.transform, limiter));
    }
}