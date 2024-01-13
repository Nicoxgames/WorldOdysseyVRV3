using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour
{
    public GameObject objectToRotate;
    public Slider rotationSlider;

    private void Start()
    {
        if (objectToRotate == null)
        {
            Debug.LogError("Please assign the GameObject to rotate in the Inspector.");
            enabled = false; // Disable the script if the object is not assigned.
            return;
        }

        // Subscribe to the slider value change event
        rotationSlider.onValueChanged.AddListener(RotateObject);
    }

    private void RotateObject(float sliderValue)
    {
        // Calculate the rotation angle based on the slider value (0 to 1) and map it to a range from 1 to 180 degrees
        float targetRotation = Mathf.Lerp(0f, 360f, sliderValue);

        // Rotate the GameObject around the Y-axis
        objectToRotate.transform.rotation = Quaternion.Euler(0f, targetRotation, 0f);
    }
}
