using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "event", menuName="New/Event")]
public class DKGGameEvent : ScriptableObject
{
    private List<DKGGameEventListener> listeners = new List<DKGGameEventListener>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(DKGGameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnRegisterListener(DKGGameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
