using UnityEngine;

public class SingleDoorCloseAndOpen : MonoBehaviour
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

<<<<<<< Updated upstream
        if (distance <= interactionDistance && Input.GetKeyDown(KeyCode.E))
=======
        if (distance <= interactionDistance &&
            (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.O)))
>>>>>>> Stashed changes
        {
            isOpen = !isOpen;

            if (isOpen)
            {
                transform.localRotation = openRotation;
            }
            else
            {
<<<<<<< Updated upstream
                transform.localRotation = closedRotation;
=======
                if (door != null)
                    door.transform.Rotate(0, -90, 0);
                else
                    transform.localRotation = closedRotation;
>>>>>>> Stashed changes
            }
        }
    }
}