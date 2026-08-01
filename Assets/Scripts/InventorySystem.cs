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

        itemToAdd = Instantiate(prefab,
            whatSlotToEquip.transform.position,
            whatSlotToEquip.transform.rotation);

        itemToAdd.transform.SetParent(whatSlotToEquip.transform, false);

        itemList.Add(itemName);

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
}






