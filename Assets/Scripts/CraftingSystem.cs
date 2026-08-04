using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
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
    private Button CraftingButton;

    // Requirement Text
    private TMP_Text AxeReq1, AxeReq2;

    public bool isOpen;


    public BluePrint AxeBlp = new BluePrint("Axe", "Jar", "", 1, 0, 1);

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




        ToolsButton = craftingScreenUI.transform.Find("ToolsButton").GetComponent<Button>();
        ToolsButton.onClick.AddListener(delegate { OpenToolsCategory(); });

        AxeReq1 = ToolsScreenUI.transform.Find("Axe").Find("req1").GetComponent<TMP_Text>();
        AxeReq2 = ToolsScreenUI.transform.Find("Axe").Find("req2").GetComponent<TMP_Text>();

        CraftingButton = ToolsScreenUI.transform.Find("Axe").transform.Find("CraftingButton").GetComponent<Button>();
        CraftingButton.onClick.AddListener(delegate { CraftAnyltem(AxeBlp); });







    }

    private void OpenToolsCategory()
    {

        craftingScreenUI.SetActive(false);
        ToolsScreenUI.SetActive(true);

    }

    void CraftAnyltem(BluePrint blueprintToCraft)
    {
        InventorySystem.Instance.AddToInventory(blueprintToCraft.itemName);

        if (blueprintToCraft.numOfRequirements == 1)
        {
            InventorySystem.Instance.RemoveItem(blueprintToCraft.Req1, blueprintToCraft.Req1Amount);
        }else if (blueprintToCraft.numOfRequirements == 2)
        {
            InventorySystem.Instance.RemoveItem(blueprintToCraft.Req1, blueprintToCraft.Req1Amount);
            InventorySystem.Instance.RemoveItem(blueprintToCraft.Req2, blueprintToCraft.Req2Amount);
        }



        InventorySystem.Instance.RecalculateList();

        RefreshNeededItems();
    }

    void OpenToolsCatergory()
    {
        craftingScreenUI.SetActive(false);
        ToolsScreenUI.SetActive(true);

        RefreshNeededItems();
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
   
    

     public void RefreshNeededItems()
    {
        int Jar_Count = 0;
        int Book_Count = 0;

        inventoryitemlist = InventorySystem.Instance.itemList;

        foreach (string itemName in inventoryitemlist)
        {
            switch (itemName)
            {
                case "Jar":
                    Jar_Count += 1;
                    break;
                case "Book":
                   Book_Count += 1;
                    break;
            }
        }

        if (Jar_Count > 0)
        {
            AxeReq1.text = "Jar[" + Jar_Count + "]";
        }
        else
        {
            AxeReq1.text = "";
        }

        if (Book_Count > 0)
        {
            AxeReq2.text = "Book[" + Book_Count + "]";
        }
        else
        {
            AxeReq2.text = "";
        }

        if (Jar_Count >= 1 && Book_Count >= 1)
        {
            CraftingButton.gameObject.SetActive(true);
        }
        else
        {
            CraftingButton.gameObject.SetActive(false);
        }



    }
}