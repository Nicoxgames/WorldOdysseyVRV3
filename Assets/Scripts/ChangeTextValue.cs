using UnityEngine;
using TMPro;

public class ChangeTextMeshProValue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;  // Reference to the TextMeshPro component in the inspector
    public float minValue = 0f;
    public float maxValue = 100f;
    public float changeAmount = 1f;

    [SerializeField]
    private string customUnit = "Unity";

    private float currentValue;

    private void Start()
    {
        if (textComponent == null)
        {
            Debug.LogError("TextMeshPro component not assigned. Please assign the TextMeshPro component in the inspector.");
        }
        else
        {
            InvokeRepeating("ChangeTextValueEverySecond", 0f, 1f);
        }
    }

    private void ChangeTextValueEverySecond()
    {
        // Change the value gradually
        float randomChange = Random.Range(-changeAmount, changeAmount);
        currentValue = Mathf.Clamp(currentValue + randomChange, minValue, maxValue);

        // Update the TextMeshPro component with the new value and unit
        textComponent.text = $"{currentValue.ToString("F2")} {customUnit}";
    }
}
