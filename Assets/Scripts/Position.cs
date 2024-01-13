using UnityEngine;
using UnityEngine.UI;

public class Position : MonoBehaviour
{
    public GameObject objectToMove;
    public Slider positionSlider;

    private void Start()
    {
        if (objectToMove == null)
        {
            Debug.LogError("Please assign the GameObject to move in the Inspector.");
            enabled = false; // Disable the script if the object is not assigned.
            return;
        }

        // Subscribe to the slider value change event
        positionSlider.onValueChanged.AddListener(MoveObject);
    }

    private void MoveObject(float sliderValue)
    {
        // Calculate the target Y position based on the slider value (0 to 1) and map it to a range from 0.2125776 to 0.5
        float targetYPosition = Mathf.Lerp(0f, 1.5f, sliderValue);

        // Set the Y position of the GameObject
        Vector3 newPosition = objectToMove.transform.position;
        newPosition.y = targetYPosition;
        objectToMove.transform.position = newPosition;
    }
}
