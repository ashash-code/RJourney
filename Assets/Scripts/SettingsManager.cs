using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameObject playerInfoContent;
    public GameObject gameSettingsContent;
    public GameObject languagesContent;
    public GameObject controlsContent;

    public Button playerInfoButton;
    public Button gameSettingsButton;
    public Button languagesButton;
    public Button controlsButton;

    // Extra highlight bars (child Images sa gilid ng buttons)
    public Image playerInfoHighlight;
    public Image gameSettingsHighlight;
    public Image languagesHighlight;
    public Image controlsHighlight;

    void Start()
    {
        ShowPlayerInfo(); // Default: Player Info agad
    }

    public void ShowPlayerInfo() { HideAll(); playerInfoContent.SetActive(true); Highlight(playerInfoHighlight); }
    public void ShowGameSettings() { HideAll(); gameSettingsContent.SetActive(true); Highlight(gameSettingsHighlight); }
    public void ShowLanguages() { HideAll(); languagesContent.SetActive(true); Highlight(languagesHighlight); }
    public void ShowControls() { HideAll(); controlsContent.SetActive(true); Highlight(controlsHighlight); }

    void HideAll()
    {
        playerInfoContent.SetActive(false);
        gameSettingsContent.SetActive(false);
        languagesContent.SetActive(false);
        controlsContent.SetActive(false);
    }

    void Highlight(Image active)
    {
        // Reset lahat ng highlight bars
        playerInfoHighlight.color = Color.clear;
        gameSettingsHighlight.color = Color.clear;
        languagesHighlight.color = Color.clear;
        controlsHighlight.color = Color.clear;

        // Sabay agad mag-highlight yung gilid ng active button
        active.color = Color.yellow;
    }
}
