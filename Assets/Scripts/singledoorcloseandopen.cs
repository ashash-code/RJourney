using UnityEngine;

public class SingleDoorCloseAndOpen : MonoBehaviour
{
    public GameObject door;
    public float interactionDistance = 5f;

    private Transform player;
    private bool isOpen = false;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
<<<<<<< Updated upstream
        var playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj != null ? playerObj.transform : null;
=======
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
>>>>>>> Stashed changes

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

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= interactionDistance &&
            (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.O)))
        {
            isOpen = !isOpen;

            if (isOpen)
            {
                if (door != null)
                    door.transform.Rotate(0, 90, 0);
                else
                    transform.localRotation = openRotation;
            }
            else
            {
<<<<<<< Updated upstream
                if (door != null)
                    door.transform.Rotate(0, -90, 0);
                else
                    transform.localRotation = closedRotation;
=======
                transform.localRotation = closedRotation;
>>>>>>> Stashed changes
            }
        }
    }
}