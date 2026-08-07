using System.Collections;
using UnityEngine;

public class DiscardItems : MonoBehaviour
{
    public void DiscardItem()
    {
        StartCoroutine(DiscardRoutine());
    }

    IEnumerator DiscardRoutine()
    {
        if (InventorySystem.Instance.selectedItem == null)
        {
            Debug.Log("No item selected.");
            yield break;
        }

        string itemName = InventorySystem.Instance.selectedItem.name.Replace("(Clone)", "");

        InventorySystem.Instance.RemoveItem(itemName, 1);

        if (InteractableObject.WorldItems.ContainsKey(itemName))
        {
            InteractableObject.WorldItems[itemName].SetActive(true);
        }

        InventorySystem.Instance.selectedItem = null;

        // Hintayin munang ma-destroy ang object
        yield return null;

        InventorySystem.Instance.RecalculateList();
        CraftingSystem.Instance.RefreshNeededItems();
    }
}