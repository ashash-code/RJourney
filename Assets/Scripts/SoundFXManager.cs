using UnityEngine;
using UnityEngine.UI;

public class SoundFXManager : MonoBehaviour
{
    public AudioSource sfxSource;   // AudioSource na tutunog
    public AudioClip clickSound;    // SFX file (hal. click.mp3)
    public Slider sfxSlider;        // UI slider para sa volume

    void Start()
    {
        // Default volume (hal. 0.7 para mas malakas, gaya ng ibang laro)
        sfxSource.volume = 20f;

        // Sync slider sa kasalukuyang volume
        sfxSlider.value = sfxSource.volume;

        // Kapag gumalaw yung slider → update volume
        sfxSlider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float value)
    {
        sfxSource.volume = value;
    }

    public void PlayClick()
    {
        sfxSource.PlayOneShot(clickSound);
    }
}
