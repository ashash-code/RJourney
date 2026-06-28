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
        player = FindObjectOfType<CharacterController>()?.transform;
        if (player == null)
        {
            player = FindObjectOfType<Rigidbody>()?.transform;
        }
        if (player == null)
        {
            player = GameObject.Find("Player")?.transform;
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
        }
    }

    void Update()
    {
    void Update()
    {
        float distance = (player == null) ? float.MaxValue : Vector3.Distance(player.position, transform.position);

        if (!playerInRange && distance > interactionDistance) return;

        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.O))
        {
            if (!isOpen)
        {
            if (!isOpen)
            {
                doorL.transform.localRotation = Quaternion.Euler(0, -90, 0);
                doorR.transform.localRotation = Quaternion.Euler(0, 90, 0);
                isOpen = true;
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