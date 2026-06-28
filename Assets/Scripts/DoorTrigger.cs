using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject doorL;
    public GameObject doorR;
    public float interactionDistance = 80f;
    public DoorMessage doorMessage;

    private bool isOpen = false;
    private bool playerInRange = false;
    private Transform player;

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

        if (!playerInRange && distance > interactionDistance)
            return;

        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.O))
        {
            if (!isOpen)
            {
                doorL.transform.localRotation = Quaternion.Euler(0, -90, 0);
                doorR.transform.localRotation = Quaternion.Euler(0, 90, 0);
                isOpen = true;

                if (doorMessage != null)
                {
                    doorMessage.HideForever();
                }
            }
            else
            {
                doorL.transform.localRotation = Quaternion.Euler(0, 0, 0);
                doorR.transform.localRotation = Quaternion.Euler(0, 0, 0);
                isOpen = false;
            }
        }
    }
}