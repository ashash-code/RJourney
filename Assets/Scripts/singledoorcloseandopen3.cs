using UnityEngine;

public class SingleDoorCloseAndOpen3 : MonoBehaviour
{
    public GameObject door;
    public float interactionDistance = 5f;

    private Transform player;
    private bool isOpen = false;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        var playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj != null ? playerObj.transform : null;

        closedRotation = transform.localRotation;
        openRotation = Quaternion.Euler(
            transform.localEulerAngles.x,
            transform.localEulerAngles.y + 90,
            transform.localEulerAngles.z
        );
    }
    }

    void Update()
    {
    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= interactionDistance && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.O)))
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
                if (door != null)
                    door.transform.Rotate(0, -90, 0);
                else
                    transform.localRotation = closedRotation;
            }
        }
    }
            }
        }
    }
}