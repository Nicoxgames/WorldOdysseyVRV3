using UnityEngine;
using TMPro;
using SpeechLib;
using UnityEngine.UI;

public class ReadOut : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string preSpeechText = "Before speaking: ";
    public string postSpeechText = "After speaking:";
    public Button speakButton; // Reference to the UI button

    // Start is called before the first frame update
    void Start()
    {
        // Add a listener to the button click event
        speakButton.onClick.AddListener(SpeakText);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpeakText()
    {
        SpVoice voice = new SpVoice();

        // Concatenate the preSpeechText, textMeshPro text, and postSpeechText
        string fullText = $"{preSpeechText} {textMeshPro.text} {postSpeechText}";

        // Speak out the full text
        voice.Speak(fullText);
    }
}
