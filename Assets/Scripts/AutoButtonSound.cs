using UnityEngine;
using UnityEngine.UI;

public class AutoButtonSound : MonoBehaviour
{
    public AudioSource sfxSource;   // i-drag mo yung AudioSource dito
    public AudioClip clickSound;    // i-drag mo yung click.mp3 dito
    public Button[] buttons;        // i-drag mo lahat ng UI Buttons dito

    void Start()
    {
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(() => sfxSource.PlayOneShot(clickSound));
        }
    }
}
