using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool playerinRange;
    public string ItemName;

    // Stores all world items
    public static Dictionary<string, GameObject> WorldItems = new Dictionary<string, GameObject>();

    private void Awake()
    {
        if (!WorldItems.ContainsKey(ItemName))
        {
            WorldItems.Add(ItemName, gameObject);
            Debug.Log("Registered: " + ItemName);
        }
    }
    public string GetItemName()
    {
        return ItemName;
    }

    void Update()
    {
        if (playerinRange && Input.GetMouseButtonDown(0))
        {
            if (!InventorySystem.Instance.CheckIfFull())
            {
                InventorySystem.Instance.AddToInventory(ItemName);

                Debug.Log("Item added to inventory: " + ItemName);

                // Hide the item instead of destroying it
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Inventory is full");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerinRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerinRange = false;
        }
    }
}