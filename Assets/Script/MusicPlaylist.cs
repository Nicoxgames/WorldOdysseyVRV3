using UnityEngine;
using UnityEngine.UI;

public class MusicPlaylist : MonoBehaviour
{
    public Button playNextButton;
    public Button playPauseButton;
    public Slider volumeSlider;
    public AudioClip[] audioClips;

    private AudioSource audioSource;
    private int currentClipIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        playNextButton.onClick.AddListener(PlayNextClip);
        playPauseButton.onClick.AddListener(TogglePlayPause);
        volumeSlider.onValueChanged.AddListener(VolumeSliderValueChanged);

        if (audioClips.Length > 0)
        {
            audioSource.clip = audioClips[currentClipIndex];
            audioSource.volume = volumeSlider.value;
        }

        audioSource.loop = false;
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f;
        audioSource.Stop();
    }

    void Update()
    {
        if (audioSource.isPlaying && audioSource.time >= audioSource.clip.length)
        {
            PlayNextClip();
        }
    }

    void PlayNextClip()
    {
        currentClipIndex = (currentClipIndex + 1) % audioClips.Length;
        audioSource.clip = audioClips[currentClipIndex];
        audioSource.Play();
    }

    void TogglePlayPause()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.UnPause();
        }
    }

    void VolumeSliderValueChanged(float value)
    {
        audioSource.volume = value;
    }
}
