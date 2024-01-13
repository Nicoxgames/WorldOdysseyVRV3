using UnityEngine;
using UnityEngine.UI;

public class RotateSliders : MonoBehaviour
{
    public Slider xSlider;
    public Slider ySlider;
    public Slider zSlider;
    public GameObject rotatingObject;

    void Update()
    {
        // Rotate the object around the Y axis based on the value of the Y slider
        float yRotation = ySlider.value * 360f;
        // Rotate the object around the X axis based on the value of the X slider
        float xRotation = xSlider.value * 360f;
        // Rotate the object around the Z axis based on the value of the Z slider
        float zRotation = zSlider.value * 360f;

        rotatingObject.transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);
    }
}
