using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GraphicsSelector : MonoBehaviour
{
    public TMP_Text graphicsText;   // TMP Text para ipakita yung kasalukuyang value
    public Button leftButton;       // ◀ button
    public Button rightButton;      // ▶ button

    private string[] graphicsOptions = { "Low", "Medium", "High", "Ultra" };
    private int currentIndex = 1; // Default = Medium

    void Start()
    {
        UpdateGraphicsText();
        leftButton.onClick.AddListener(PreviousOption);
        rightButton.onClick.AddListener(NextOption);
    }

    void UpdateGraphicsText()
    {
        if (graphicsText != null)
            graphicsText.text = graphicsOptions[currentIndex];
    }

    void PreviousOption()
    {
        currentIndex--;
        if (currentIndex < 0) currentIndex = graphicsOptions.Length - 1;
        UpdateGraphicsText();
    }

    void NextOption()
    {
        currentIndex++;
        if (currentIndex >= graphicsOptions.Length) currentIndex = 0;
        UpdateGraphicsText();
    }
}
