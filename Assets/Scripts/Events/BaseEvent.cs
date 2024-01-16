public class BaseEvent
{
    public virtual string EventName { get; private set; }
    public virtual float Duration { get; private set; } = 10;

    public virtual void Activate()
    {

    }
    public virtual void Deactivate() 
    {

    }
}
