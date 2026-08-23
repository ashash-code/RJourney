using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowNotifSelector : MonoBehaviour
{
    public TMP_Text shownotifText;   // TMP Text para ipakita yung value
    public Button leftButton;        // ◀ button
    public Button rightButton;       // ▶ button

    private string[] shownotifOptions = { "Off", "On" };
    private int currentIndex = 1; // Default = On

    void Start()
    {
        UpdateShowNotifText();
        leftButton.onClick.AddListener(PreviousOption);
        rightButton.onClick.AddListener(NextOption);
    }

    void UpdateShowNotifText()
    {
        shownotifText.text = shownotifOptions[currentIndex];
    }

    void PreviousOption()
    {
        currentIndex--;
        if (currentIndex < 0) currentIndex = shownotifOptions.Length - 1;
        UpdateShowNotifText();
    }

    void NextOption()
    {
        currentIndex++;
        if (currentIndex >= shownotifOptions.Length) currentIndex = 0;
        UpdateShowNotifText();
    }
}
