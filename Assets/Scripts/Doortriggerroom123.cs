using UnityEngine;

public class DoorTriggerroom123 : MonoBehaviour
{
    public GameObject door;
    public float interactionDistance = 80f;

    private bool isOpen = false;
    private Transform player;

    void Start()
    {
        player = FindAnyObjectByType<CharacterController>()?.transform;

        if (player == null)
        {
            player = GameObject.Find("Player")?.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(player.position, transform.position);

        if (Input.GetKeyDown(KeyCode.E) && distance <= interactionDistance)
        {
            if (!isOpen)
            {
                door.transform.localRotation = Quaternion.Euler(0, 90, 0);
                isOpen = true;
            }
            else
            {
                door.transform.localRotation = Quaternion.Euler(0, 0, 0);
                isOpen = false;
            }
        }
    }
}