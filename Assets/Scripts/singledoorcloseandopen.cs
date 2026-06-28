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
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
        var playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj != null ? playerObj.transform : null;
=======
>>>>>>> 1736babd4d6c2295cca066ed8e236f94e848a213
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
<<<<<<< HEAD
=======
>>>>>>> Stashed changes
>>>>>>> 1736babd4d6c2295cca066ed8e236f94e848a213

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
                transform.localRotation = openRotation;
            }
            else
            {
<<<<<<< HEAD
                transform.localRotation = closedRotation;
=======
<<<<<<< Updated upstream
                if (door != null)
                    door.transform.Rotate(0, -90, 0);
                else
                    transform.localRotation = closedRotation;
=======
                transform.localRotation = closedRotation;
>>>>>>> Stashed changes
>>>>>>> 1736babd4d6c2295cca066ed8e236f94e848a213
            }
        }
    }
}