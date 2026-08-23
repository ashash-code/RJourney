using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VibrationSelector : MonoBehaviour
{
    public TMP_Text vibrationText;   // TMP Text para ipakita yung value
    public Button leftButton;        // ◀ button
    public Button rightButton;       // ▶ button

    private string[] vibrationOptions = { "Off", "On" };
    private int currentIndex = 1; // Default = On

    void Start()
    {
        UpdateVibrationText();
        leftButton.onClick.AddListener(PreviousOption);
        rightButton.onClick.AddListener(NextOption);
    }

    void UpdateVibrationText()
    {
        vibrationText.text = vibrationOptions[currentIndex];
    }

    void PreviousOption()
    {
        currentIndex--;
        if (currentIndex < 0) currentIndex = vibrationOptions.Length - 1;
        UpdateVibrationText();
    }

    void NextOption()
    {
        currentIndex++;
        if (currentIndex >= vibrationOptions.Length) currentIndex = 0;
        UpdateVibrationText();
    }
}
