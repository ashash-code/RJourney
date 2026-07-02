using UnityEngine;

public class DoorTriggerroom123 : MonoBehaviour
{
    public GameObject door;

    private bool isOpen = false;
    private bool playerInRange = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }

    void Update()
    {
        if (!playerInRange) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen;

            door.transform.localRotation = Quaternion.Euler(0, isOpen ? 90 : 0, 0);
        }
    }
}