using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class EventManager : MonoBehaviour, IPauseable
{
    [SerializeField] private TextMeshProUGUI alertMessage, currentEvent;
    [Inject] private PauseManager pauseManager;
    [Inject] private MeteorRainEvent rainEvent;
    [Inject] private ChangeMovementEvent changeMovementEvent;
    private List<BaseEvent> events = new List<BaseEvent>();
    public bool IsPaused {  get; set; }

    private float currentTime = 0;
    private int timeToEvent;
    private const int MIN_TIME_TO_EVENT = 15;
    private const int MAX_TIME_TO_EVENT = 20;
    private int currentEventIndex;
    private bool eventActivated = false;

    public void Initialize()
    {
        pauseManager.Register(this);
        timeToEvent = Random.Range(MIN_TIME_TO_EVENT, MAX_TIME_TO_EVENT);
        InitEvents();
    }

    private void Update()
    {
        if (IsPaused)
            return;

        if (eventActivated == false)
        {
            CountdownToEvent();
        }
        else
        {
            EventCountdown();
        }

    }

    private void CountdownToEvent()
    {
        if (currentTime < timeToEvent)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            currentTime = 0;
            timeToEvent = Random.Range(MIN_TIME_TO_EVENT, MAX_TIME_TO_EVENT);
            currentEventIndex = Random.Range(0, events.Count);
            events[currentEventIndex].Activate();
            StartCoroutine(Alert(events[currentEventIndex].EventName));
            eventActivated = true;
        }
    }

    private IEnumerator Alert(string message)
    {
        alertMessage.text = message;

        while (alertMessage.transform.localScale.x <= 1.2f)
        {
            alertMessage.transform.localScale = new Vector2(
                alertMessage.transform.localScale.x + Time.deltaTime,
                alertMessage.transform.localScale.y + Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(2);

        while (alertMessage.transform.localScale.x >= 0)
        {
            alertMessage.transform.localScale = new Vector2(
                alertMessage.transform.localScale.x - Time.deltaTime,
                alertMessage.transform.localScale.y - Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }

        alertMessage.text = string.Empty;
        alertMessage.transform.localScale = Vector2.zero;
    }

    private void CountdownToEndOfEvent(string eventName, float time)
    {
        currentEvent.text = $"{eventName} {Mathf.Ceil(events[currentEventIndex].Duration - time)}";
    }

    private void EventCountdown()
    {
        if (currentTime < events[currentEventIndex].Duration)
        {
            currentTime += Time.deltaTime;
            CountdownToEndOfEvent(events[currentEventIndex].EventName, currentTime);
        }
        else
        {
            events[currentEventIndex].Deactivate();
            currentTime = 0;
            eventActivated = false;
            currentEvent.text = string.Empty;
        }
    }

    private void InitEvents()
    {
        events.Add(new CameraRevertEvent(this));
        events.Add(changeMovementEvent);
        events.Add(rainEvent);
    }
}
