using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject doorL;
    public GameObject doorR;
    public float interactionDistance = 80f;

    private bool isOpen = false;
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

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(player.position, transform.position);

        if (Input.GetKeyDown(KeyCode.O) && distance <= interactionDistance)
        {
            if (!isOpen)
            {
                doorL.transform.localRotation = Quaternion.Euler(0, -90, 0);
                doorR.transform.localRotation = Quaternion.Euler(0, 90, 0);
                isOpen = true;
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