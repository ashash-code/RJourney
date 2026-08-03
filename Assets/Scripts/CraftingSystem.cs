using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{
    public GameObject craftingScreenUI;
    public GameObject ToolsScreenUI;

    public List<string> inventoryitemlist = new List<string>();

    // Category Button
    private Button ToolsButton;

    // Crafting Buttons
    private Button craftAxeBTN;

    // Requirement Text
    private Text AxeReq1, AxeReq2;

    public bool isOpen;

    public static CraftingSystem Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        isOpen = false;

        // Hide crafting screens at the start
        craftingScreenUI.SetActive(false);
        ToolsScreenUI.SetActive(false);

        // Find the ToolsButton
        Transform buttonTransform = craftingScreenUI.transform.Find("ToolsButton");

        if (buttonTransform == null)
        {
            Debug.LogError("ToolsButton was not found inside CraftingScreen.");
            return;
        }

        ToolsButton = buttonTransform.GetComponent<Button>();

        if (ToolsButton == null)
        {
            Debug.LogError("ToolsButton does not have a Button component.");
            return;
        }

        ToolsButton.onClick.AddListener(OpenToolsCatergory);
    }

    void OpenToolsCatergory()
    {
        craftingScreenUI.SetActive(false);
        ToolsScreenUI.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isOpen = !isOpen;

            craftingScreenUI.SetActive(isOpen);

            if (!isOpen)
            {
                ToolsScreenUI.SetActive(false);
            }
        }
    }
}