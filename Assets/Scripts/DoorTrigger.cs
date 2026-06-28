using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject doorL;
    public GameObject doorR;
    public DoorMessage doorMessage;

    private bool isOpen = false;
    private bool playerInRange = false;

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
        if (!playerInRange) return;

        if (Input.GetKeyDown(KeyCode.E))
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