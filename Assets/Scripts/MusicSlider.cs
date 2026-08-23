using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    public Slider musicSlider;
    private AudioSource musicSource;

    void Start()
    {
        // Add AudioSource kung wala pa
        musicSource = gameObject.AddComponent<AudioSource>();

        // Load audio mula sa Resources/music
        AudioClip clip = Resources.Load<AudioClip>("music");
        musicSource.clip = clip;
        musicSource.loop = true;

        // Default volume (hal. 0.5 = kalahati, gaya ng ibang laro)
        musicSource.volume = 0.5f;
        musicSource.Play();

        // Slider setup
        musicSlider.value = musicSource.volume;
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    void SetMusicVolume(float value)
    {
        musicSource.volume = value;
    }
}
