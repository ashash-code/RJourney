using UnityEngine;

public class SingleDoorCloseAndOpen2 : MonoBehaviour
{
    public float interactionDistance = 3f;

    private Transform player;
    private bool isOpen = false;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        closedRotation = transform.localRotation;
        openRotation = Quaternion.Euler(
            transform.localEulerAngles.x,
            transform.localEulerAngles.y + 90,
            transform.localEulerAngles.z
        );
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(
            player.position,
            transform.position
        );

        if (distance <= interactionDistance && Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen;

            if (isOpen)
            {
                transform.localRotation = openRotation;
            }
            else
            {
                transform.localRotation = closedRotation;
            }
        }
    }
}