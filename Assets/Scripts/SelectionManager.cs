using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectionManager : MonoBehaviour
{
    public GameObject interaction_Info_UI;
    private TMP_Text interaction_text;

    public float interactionDistance = 3f;

    public Image centerDotImage;
    public Image handIcon;

    void Start()
    {
        interaction_text = interaction_Info_UI.GetComponent<TMP_Text>();

        if (interaction_text == null)
        {
            Debug.LogError("No TMP_Text component found on interaction_Info_UI!");
        }

        interaction_Info_UI.SetActive(false);

        centerDotImage.gameObject.SetActive(true);
        handIcon.gameObject.SetActive(false);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Default
        interaction_Info_UI.SetActive(false);
        centerDotImage.gameObject.SetActive(true);
        handIcon.gameObject.SetActive(false);

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            InteractableObject interactable = hit.transform.GetComponent<InteractableObject>();

            if (interactable != null && interactable.gameObject.activeSelf)
            {
                // Show item name
                interaction_Info_UI.SetActive(true);
                interaction_text.text = interactable.GetItemName();

                // Show hand cursor
                centerDotImage.gameObject.SetActive(false);
                handIcon.gameObject.SetActive(true);

                if (Input.GetMouseButtonDown(0))
                {
                    if (!InventorySystem.Instance.CheckIfFull())
                    {
                        InventorySystem.Instance.AddToInventory(
                            interactable.GetItemName(),
                            interactable.GetItemIcon()
                        );

                        if (CraftingSystem.Instance != null)
                        {
                            CraftingSystem.Instance.RefreshNeededItems();
                        }

                        interactable.gameObject.SetActive(false);

                        interaction_Info_UI.SetActive(false);
                        handIcon.gameObject.SetActive(false);
                        centerDotImage.gameObject.SetActive(true);
                    }
                    else
                    {
                        Debug.Log("Inventory is full");
                    }
                }
            }
        }
    }
}