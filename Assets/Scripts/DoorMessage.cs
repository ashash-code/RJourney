using UnityEngine;

public class DoorMessage : MonoBehaviour
{
    public GameObject message;

    [HideInInspector]
    public bool interacted = false;

    void Start()
    {
        if (message != null)
            message.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !interacted)
        {
            if (message != null)
                message.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (message != null)
                message.SetActive(false);
        }
    }

    public void HideForever()
    {
        interacted = true;

        if (message != null)
            message.SetActive(false);
    }
}