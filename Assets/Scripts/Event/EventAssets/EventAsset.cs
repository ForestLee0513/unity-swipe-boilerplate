using System;
using UnityEngine;

public class EventAsset : ScriptableObject
{
    public event EventHandler eventRaised;

    public void Raise()
    {
        eventRaised?.Invoke(this, EventArgs.Empty);
    }
}

public class EventAsset<T> : ScriptableObject
{ 
    public event EventHandler<T> eventRaised;

    public void Raise(T arg)
    {
        eventRaised?.Invoke(this, arg);
    }
}
