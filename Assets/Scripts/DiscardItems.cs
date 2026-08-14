using System.Collections;
using TMPro;
using UnityEngine;

public class DiscardItems : MonoBehaviour
{
    public GameObject discardMessage;
    public TMP_Text discardMessageText;

    public void DiscardItem()
    {
        if (InventorySystem.Instance.selectedItem == null)
        {
            discardMessage.SetActive(true);
            discardMessageText.text = "Please select or click an object if you want to delete it.";

            StartCoroutine(HideMessage());
            return;
        }

        StartCoroutine(DiscardRoutine());
    }

    IEnumerator HideMessage()
    {
        yield return new WaitForSeconds(2f);

        discardMessage.SetActive(false);
    }

    IEnumerator DiscardRoutine()
    {
        string itemName = InventorySystem.Instance.selectedItem.name.Replace("(Clone)", "");

        InventorySystem.Instance.RemoveItem(itemName, 1);

        if (InteractableObject.WorldItems.ContainsKey(itemName))
        {
            InteractableObject.WorldItems[itemName].SetActive(true);
        }

        InventorySystem.Instance.selectedItem = null;

        yield return null;

        InventorySystem.Instance.RecalculateList();
        CraftingSystem.Instance.RefreshNeededItems();
    }
}