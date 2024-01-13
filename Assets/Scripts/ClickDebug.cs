using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ClickDetection : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI targetText;

    void Start()
    {
        // Ensure that the TextMeshProUGUI element is assigned
        if (targetText == null)
        {
            Debug.LogError("Target TextMeshProUGUI is not assigned!");
            return;
        }

        // Attach this script as a click handler to the TextMeshProUGUI element
        EventTrigger eventTrigger = targetText.gameObject.AddComponent<EventTrigger>();

        // Create an entry for the PointerClick event
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((data) => { OnPointerClick((PointerEventData)data); });

        // Add the entry to the event trigger
        eventTrigger.triggers.Add(entry);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("TextMeshProUGUI Clicked!");
    }
}
