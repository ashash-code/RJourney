using UnityEngine;
using TMPro;

public class SelectionManager : MonoBehaviour
{
    public GameObject interaction_Info_UI;
    private TMP_Text interaction_text;

    public float interactionDistance = 3f;

    void Start()
    {
        interaction_text = interaction_Info_UI.GetComponent<TMP_Text>();

        if (interaction_text == null)
        {
            Debug.LogError("No TMP_Text component found on interaction_Info_UI!");
        }

        interaction_Info_UI.SetActive(false);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            InteractableObject interactable = hit.transform.GetComponent<InteractableObject>();

            if (interactable != null)
            {
                interaction_text.text = interactable.GetItemName();
                interaction_Info_UI.SetActive(true);

                if (Input.GetMouseButtonDown(0))
                {
                    InventorySystem.Instance.AddToInventory(interactable.GetItemName());
                    CraftingSystem.Instance.RefreshNeededItems();

                    Debug.Log("Item added to inventory");
                    interactable.gameObject.SetActive(false);
                }
            }
            else
            {
                interaction_Info_UI.SetActive(false);
            }
        }
        else
        {
            interaction_Info_UI.SetActive(false);
        }
    }
}