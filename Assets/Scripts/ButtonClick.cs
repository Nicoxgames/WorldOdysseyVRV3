using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public Button button1;
    public Button button2;
    private bool buttonsFound = false;

    void Update()
    {
        if (!buttonsFound)
        {
            FindButtons();
        }
    }

    void FindButtons()
    {
        // Attempt to find a GameObject with the tag "Button1"
        GameObject button1GameObject = GameObject.FindGameObjectWithTag("Button1");

        // Assign the Button component if the GameObject is found
        if (button1GameObject != null)
        {
            button1 = button1GameObject.GetComponent<Button>();

            // Ensure that both buttons are assigned
            if (button1 == null || button2 == null)
            {
                Debug.Log("Button 1 or Button 2 is not assigned!");
                return;
            }

            buttonsFound = true; // Stop looking for buttons once found

            // Attach the methods to be called when buttons are clicked
            button1.onClick.AddListener(OnButton1Clicked);
        }
        else
        {
            Debug.Log("GameObject with tag 'Button1' not found!");
        }
    }

    void OnButton1Clicked()
    {
        Debug.Log("Button 1 Clicked!");

        // Trigger the click event on Button 2 only if Button 2 is assigned
        if (button2 != null)
        {
            ClickButton2();
        }
        else
        {
            Debug.Log("Button 2 is not assigned!");
        }
    }

    void ClickButton2()
    {
        button2.onClick.Invoke();
    }
}
