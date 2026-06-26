using UnityEngine;

public class SingleDoorCloseAndOpen3 : MonoBehaviour
{
    public GameObject door;
    public float interactionDistance = 5f;

    private Transform player;
    private bool isOpen = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= interactionDistance && Input.GetKeyDown(KeyCode.O))
        {
            if (!isOpen)
            {
                door.transform.Rotate(0, 90, 0);
                isOpen = true;
            }
            else
            {
                door.transform.Rotate(0, -90, 0);
                isOpen = false;
            }
        }
    }
}