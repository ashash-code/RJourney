using UnityEngine;

public class EntranceTrigger : MonoBehaviour
{
    private EntranceMessage entranceMessage;

    void Start()
    {
        entranceMessage = GetComponent<EntranceMessage>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        entranceMessage.playerInside = true;
        entranceMessage.ShowMessage();
    }

    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        entranceMessage.playerInside = false;
        entranceMessage.HideMessage();
    }
}