using UnityEngine;

public class DoorMessageroom123 : MonoBehaviour
{
    public GameObject message;

    public bool interacted = false;

    void Start()
    {
        message.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !interacted)
        {
            message.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            message.SetActive(false);
        }
    }
}