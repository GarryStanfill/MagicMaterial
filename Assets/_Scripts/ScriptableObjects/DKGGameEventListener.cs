using UnityEngine;
using UnityEngine.Events;

public class DKGGameEventListener : MonoBehaviour
{
    public DKGGameEvent Event;
    public UnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnRegisterListener(this);
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }
}
