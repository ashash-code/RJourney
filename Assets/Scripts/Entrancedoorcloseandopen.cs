using UnityEngine;

public class Entrancedoorcloseandopen : MonoBehaviour
{
    public GameObject doorL;
    public GameObject doorR;
    public float interactionDistance = 3f;

    private bool isOpen = false;
    private bool playerInRange = false;
    private Transform player;

    private EntranceMessage entranceMessage;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player with tag 'Player' not found!");
        }

        entranceMessage = GetComponent<EntranceMessage>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(player.position, transform.position);

        if (!playerInRange || distance > interactionDistance)
            return;

        if (!isOpen && Input.GetKeyDown(KeyCode.E))
        {
            doorL.transform.localRotation = Quaternion.Euler(0, -90, 0);
            doorR.transform.localRotation = Quaternion.Euler(0, 90, 0);

            isOpen = true;

            // Hide the entrance message forever
            if (entranceMessage != null)
            {
                entranceMessage.DoorOpened();
            }

            // Disable door colliders so they don't block the player
            Collider leftCol = doorL.GetComponent<Collider>();
            if (leftCol != null)
                leftCol.enabled = false;

            Collider rightCol = doorR.GetComponent<Collider>();
            if (rightCol != null)
                rightCol.enabled = false;
        }
    }
}