using UnityEngine;
using UnityEngine.UI;

public class TransformController : MonoBehaviour
{
    public GameObject targetObject;

    public Slider positionSlider;
    public Slider rotationSlider;
    public Slider scaleSlider;

    private void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Please assign the GameObject to transform in the Inspector.");
            enabled = false; // Disable the script if the object is not assigned.
            return;
        }

        // Subscribe to the slider value change events
        positionSlider.onValueChanged.AddListener(MoveObject);
        rotationSlider.onValueChanged.AddListener(RotateObject);
        scaleSlider.onValueChanged.AddListener(ScaleObject);
    }

    public void MoveObject(float sliderValue)
    {
        float targetYPosition = Mathf.Lerp(0f, 1.5f, sliderValue);
        Vector3 newPosition = targetObject.transform.position;
        newPosition.y = targetYPosition;
        targetObject.transform.position = newPosition;
    }

    public void RotateObject(float sliderValue)
    {
        float targetRotation = Mathf.Lerp(0f, 360f, sliderValue);
        targetObject.transform.rotation = Quaternion.Euler(0f, targetRotation, 0f);
    }

    public void ScaleObject(float sliderValue)
    {
        float scaleFactor = Mathf.Lerp(0.15f, 0.35f, sliderValue);
        targetObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }
}
