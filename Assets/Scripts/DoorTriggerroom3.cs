using UnityEngine;

public class DoorTriggerroom3 : MonoBehaviour
{
    public GameObject door;
    private DoorMessageroom3 doorMessage;

    private bool isOpen = false;
    private bool playerInRange = false;

    void Start()
    {
        doorMessage = GetComponent<DoorMessageroom3>();

        if (doorMessage == null)
        {
            Debug.LogError("DoorMessageroom3 script is missing!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            doorMessage.playerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            doorMessage.playerInside = false;
        }
    }

    void Update()
    {
        if (!playerInRange) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen;
            door.transform.localRotation = Quaternion.Euler(0, isOpen ? 90 : 0, 0);

            if (isOpen)
                doorMessage.OpenDoor();
        }
    }
}