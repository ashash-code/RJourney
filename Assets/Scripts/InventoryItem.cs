using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class InventoryItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    // --- Is this item trashable --- //
    public bool isTrashable;

    // --- Item Info UI --- //
    private GameObject itemInfoUI;

    private TMP_Text itemInfoUI_itemName;
    private TMP_Text itemInfoUI_itemDescription;

    public string thisName, thisDescription;

    // --- Consumption --- //
    private GameObject itemPendingConsumption;
    public bool isConsumable;

    public float healthEffect;
    public float caloriesEffect;

    // --- Selected Item Highlight --- //
    private static InventoryItem selectedInventoryItem;
    private Outline selectionOutline;


    private void Start()
    {
        itemInfoUI = InventorySystem.Instance.ItemInfoUI;

        itemInfoUI_itemName =
            itemInfoUI.transform.Find("ItemName").GetComponent<TMP_Text>();

        itemInfoUI_itemDescription =
            itemInfoUI.transform.Find("ItemDescription").GetComponent<TMP_Text>();

        // Highlight component for THIS inventory item
        selectionOutline = GetComponent<Outline>();

        if (selectionOutline == null)
        {
            selectionOutline = gameObject.AddComponent<Outline>();
        }

        selectionOutline.effectColor = Color.yellow;
        selectionOutline.effectDistance = new Vector2(4f, 4f);

        // Don't show highlight when inventory starts
        selectionOutline.enabled = false;
    }


    // Triggered when the mouse enters into the area of the item
    public void OnPointerEnter(PointerEventData eventData)
    {
        itemInfoUI.SetActive(true);

        string itemName = thisName;

        if (string.IsNullOrEmpty(itemName))
        {
            itemName = gameObject.name.Replace("(Clone)", "").Trim();
        }

        itemInfoUI_itemName.text = itemName;
        itemInfoUI_itemDescription.text = thisDescription;
    }


    // Triggered when the mouse exits the area of the item
    public void OnPointerExit(PointerEventData eventData)
    {
        itemInfoUI.SetActive(false);
    }


    // Triggered when the mouse is clicked over the item
    public void OnPointerDown(PointerEventData eventData)
    {
        // LEFT CLICK = SELECT ITEM
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Remove highlight from previous selected item
            if (selectedInventoryItem != null &&
                selectedInventoryItem != this)
            {
                selectedInventoryItem.selectionOutline.enabled = false;
            }

            // This is now the selected item
            selectedInventoryItem = this;

            // Tell InventorySystem which item is selected
            InventorySystem.Instance.selectedItem = gameObject;

            // Highlight THIS Jar / item
            selectionOutline.enabled = true;

            Debug.Log("Selected: " + gameObject.name);
        }

        // RIGHT CLICK = CONSUME
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (isConsumable)
            {
                itemPendingConsumption = gameObject;

                consumingFunction(
                    healthEffect,
                    caloriesEffect
                );
            }
        }
    }


    // Triggered when the mouse button is released
    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (isConsumable && itemPendingConsumption == gameObject)
            {
                DestroyImmediate(gameObject);

                InventorySystem.Instance.RecalculateList();

                CraftingSystem.Instance.RefreshNeededItems();
            }
        }
    }


    private void consumingFunction(float healthEffect, float caloriesEffect)
    {
        itemInfoUI.SetActive(false);

        healthEffectCalculation(healthEffect);
        caloriesEffectCalculation(caloriesEffect);
    }


    private static void healthEffectCalculation(float healthEffect)
    {
        float healthBeforeConsumption =
            PlayerState.Instance.currentHealth;

        float maxHealth =
            PlayerState.Instance.maxHealth;

        if (healthEffect != 0)
        {
            PlayerState.Instance.currentHealth =
                Mathf.Min(
                    healthBeforeConsumption + healthEffect,
                    maxHealth
                );
        }
    }


    private static void caloriesEffectCalculation(float caloriesEffect)
    {
        float caloriesBeforeConsumption =
            PlayerState.Instance.currentCalories;

        float maxCalories =
            PlayerState.Instance.maxCalories;

        if (caloriesEffect != 0)
        {
            PlayerState.Instance.currentCalories =
                Mathf.Min(
                    caloriesBeforeConsumption + caloriesEffect,
                    maxCalories
                );
        }
    }


    // Called after the selected item is discarded
    public static void ClearSelection()
    {
        if (selectedInventoryItem != null)
        {
            if (selectedInventoryItem.selectionOutline != null)
            {
                selectedInventoryItem.selectionOutline.enabled = false;
            }

            selectedInventoryItem = null;
        }
    }
}