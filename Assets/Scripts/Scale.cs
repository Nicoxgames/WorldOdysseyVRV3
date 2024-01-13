using UnityEngine;
using UnityEngine.UI;

public class Scale : MonoBehaviour
{
    public GameObject objectToScale;
    public Slider scaleSlider;

    private void Start()
    {
        if (objectToScale == null)
        {
            Debug.LogError("Please assign the GameObject to scale in the Inspector.");
            enabled = false; // Disable the script if the object is not assigned.
            return;
        }

        // Subscribe to the slider value change event
        scaleSlider.onValueChanged.AddListener(ScaleObject);
    }

    private void ScaleObject(float sliderValue)
    {
        // Calculate the scale factor based on the slider value (0 to 1) and map it to a range from 0.2 to 0.6
        float scaleFactor = Mathf.Lerp(.15f, .35f, sliderValue);

        // Set the scale of the GameObject on all axes
        objectToScale.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }
}
