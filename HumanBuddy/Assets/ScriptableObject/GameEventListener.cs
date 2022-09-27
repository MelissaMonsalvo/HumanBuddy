using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "EventListener", menuName = "Game/EventListener")]

public class GameEventListener : MonoBehaviour
{
    [Tooltip("El evento al que queremos registrarnos")]
    public GameEvent Event;

    [Tooltip("Las llamadas que queremos invocar cuando el Event es lanzado")]
    public UnityEvent Response;
    public void OnEventRaised()
    {
        Response.Invoke();
    }

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }
}
