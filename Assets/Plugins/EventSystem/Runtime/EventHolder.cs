using System;

public class EventHolder
{
    private event Action EventContainer = () => { };

    public void Trigger()
    {
        EventContainer?.Invoke();
    }

    public void Add(Action action)
    {
        EventContainer += action;
    }

    public void Remove(Action action)
    {
        EventContainer -= action;
    }

    public void Clear()
    {
        EventContainer = () => { };
    }
}
