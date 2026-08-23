using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VideoQualitySelector : MonoBehaviour
{
    public TMP_Text videoQualityText;   // TMP Text para ipakita yung value
    public Button leftButton;           // ◀ button
    public Button rightButton;          // ▶ button

    private string[] qualityOptions = { "720p", "1080p", "1440p", "4K" };
    private int currentIndex = 1; // Default = 1080p

    void Start()
    {
        UpdateQualityText();
        leftButton.onClick.AddListener(PreviousOption);
        rightButton.onClick.AddListener(NextOption);
    }

    void UpdateQualityText()
    {
        videoQualityText.text = qualityOptions[currentIndex];
    }

    void PreviousOption()
    {
        currentIndex--;
        if (currentIndex < 0) currentIndex = qualityOptions.Length - 1;
        UpdateQualityText();
    }

    void NextOption()
    {
        currentIndex++;
        if (currentIndex >= qualityOptions.Length) currentIndex = 0;
        UpdateQualityText();
    }
}
