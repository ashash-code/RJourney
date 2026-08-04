using System;
using System.Collections;
using System.Collections.Generic;

using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class InventorySystem : MonoBehaviour
{

    public static InventorySystem Instance { get; set; }

    public GameObject inventoryScreenUI;

    public List<GameObject> SlotList = new List<GameObject>();

    public List<string> itemList = new List<string>();

    private GameObject whatSlotToEquip;

    public bool isOpen;

    private GameObject itemToAdd;

    public bool isFull;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        isOpen = false;

        PopulateSlotList();
    }


    private void PopulateSlotList()
    {
        foreach (Transform child in inventoryScreenUI.transform)
        {
            SlotList.Add(child.gameObject);
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !isOpen)
        {
            Debug.Log("i is pressed");

            inventoryScreenUI.SetActive(true);

            // refresh items sa slots
            foreach (GameObject slot in SlotList)
            {
                foreach (Transform item in slot.transform)
                {
                    item.gameObject.SetActive(true);
                }
            }

            isOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.I) && isOpen)
        {
            inventoryScreenUI.SetActive(false);
            isOpen = false;
        }
    }

    public void AddToInventory(string itemName)
    {
        Debug.Log("=== AddToInventory START ===");

        whatSlotToEquip = FindNextEmptySlot();
        Debug.Log("Slot found: " + whatSlotToEquip.name);

        GameObject prefab = Resources.Load<GameObject>(itemName);

        if (prefab == null)
        {
            Debug.LogError("Prefab NOT FOUND!");
            return;
        }

        itemToAdd = Instantiate(prefab);

        itemToAdd.transform.SetParent(whatSlotToEquip.transform);

        itemToAdd.transform.localPosition = Vector3.zero;
        itemToAdd.transform.localRotation = Quaternion.identity;
        itemToAdd.transform.localScale = Vector3.one;

        itemToAdd.SetActive(true);

        itemList.Add(itemName);

        if (CraftingSystem.Instance != null)
        {
            CraftingSystem.Instance.RefreshNeededItems();
        }

        Debug.Log("Added: " + itemName);
        Debug.Log("ItemList Count = " + itemList.Count);
        Debug.Log("=== AddToInventory END ===");
    }
    private GameObject FindNextEmptySlot()
    {
        foreach (GameObject slot in SlotList)

        {
            if (slot.transform.childCount == 0)
            {
                return slot;


            }
        }
        return new GameObject();
    }




    public bool CheckIfFull()
    {
        int counter = 0;

        foreach (GameObject slot in SlotList)
        {
            if (slot.transform.childCount > 0)
            {
                counter++;
            }
        }

        return counter >= SlotList.Count;
    }
    public void RemoveItem(string nameToRemove, int amountToRemove)
    {
        int counter = amountToRemove;
        for (var i = SlotList.Count - 1; i >= 0; i--)
        {
            if (SlotList[i].transform.childCount > 0)
            {
                if (SlotList[i].transform.GetChild(0).name == nameToRemove + "(Clone)" && counter != 0)
                {
                    Destroy(SlotList[i].transform.GetChild(0).gameObject);
                    counter -= 1;
                }
            }

        }
    }
    public void RecalculateList()
    {
        itemList.Clear();
        foreach (GameObject slot in SlotList)
        {
            if (slot.transform.childCount > 0)
            {
                string name = slot.transform.GetChild(0).name;
                string str1 = name;
                string str2 = "(Clone)";

                string result = name.Replace(str2, "");
                itemList.Add(result);
            }
        }

    }
}





