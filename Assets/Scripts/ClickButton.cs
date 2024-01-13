using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour
{
    public Button targetButton;
    public bool clickButton;

    void Update()
    {
        if (clickButton)
        {
            ClickTargetButton();
            clickButton = false;
        }
    }

    public void ClickTargetButton()
    {
        if (targetButton != null)
        {
            targetButton.onClick.Invoke();
        }
        else
        {
            Debug.LogWarning("Target Button is not assigned.");
        }
    }
}
