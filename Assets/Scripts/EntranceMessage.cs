using UnityEngine;

public class EntranceMessage : MonoBehaviour
{
    public GameObject messageUI;
    [HideInInspector] public bool playerInside = false;
    private bool doorOpened = false;

    void Start()
    {
        if (messageUI != null)
            messageUI.SetActive(false); // default hidden
    }

    public void ShowMessage()
    {
        if (doorOpened) return; // huwag ipakita kung bukas na ang pinto
        if (messageUI != null) messageUI.SetActive(true);
    }

    public void HideMessage()
    {
        if (messageUI != null) messageUI.SetActive(false);
    }

    public void DoorOpened()
    {
        doorOpened = true;
        HideMessage(); // itago permanently
    }
}
