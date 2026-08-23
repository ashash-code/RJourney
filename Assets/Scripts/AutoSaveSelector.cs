using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AutoSaveSelector : MonoBehaviour
{
    public TMP_Text autosaveText;   // TMP Text para ipakita yung value
    public Button leftButton;        // ◀ button
    public Button rightButton;       // ▶ button

    private string[] autosaveOptions = { "Off", "On" };
    private int currentIndex = 1; // Default = On

    void Start()
    {
        UpdateAutoSaveText();
        leftButton.onClick.AddListener(PreviousOption);
        rightButton.onClick.AddListener(NextOption);
    }

    void UpdateAutoSaveText()
    {
        autosaveText.text = autosaveOptions[currentIndex];
    }

    void PreviousOption()
    {
        currentIndex--;
        if (currentIndex < 0) currentIndex = autosaveOptions.Length - 1;
        UpdateAutoSaveText();
    }

    void NextOption()
    {
        currentIndex++;
        if (currentIndex >= autosaveOptions.Length) currentIndex = 0;
        UpdateAutoSaveText();
    }
}
