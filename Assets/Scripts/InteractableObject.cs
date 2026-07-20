using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool playerinRange;
    public string ItemName;

    public string GetItemName()
    {
        return ItemName;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Clicked");
        }

        if (playerinRange)
        {
            Debug.Log("Player In Range");
        }

        if (playerinRange && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Item added to inventory: " + ItemName);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerinRange = true;
            Debug.Log("Player entered range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerinRange = false;
            Debug.Log("Player left range");
        }
    }
}