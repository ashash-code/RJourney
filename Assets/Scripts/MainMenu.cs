using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject aboutPanel;

    public void OpenAbout()
    {
        mainMenu.SetActive(false);
        aboutPanel.SetActive(true);
    }

    public void CloseAbout()
    {
        aboutPanel.SetActive(false);
        mainMenu.SetActive(true);
    }
}