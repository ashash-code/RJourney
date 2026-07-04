using UnityEngine;
using System.Numerics;

public class DoorMessageroom1 : MonoBehaviour
{
    public GameObject message;

    public bool playerInside = false;
    public bool doorOpened = false;

    void Start()
    {
        message.SetActive(false);
    }

    void Update()
    {
        if (playerInside && !doorOpened)
        {
            Debug.Log(gameObject.name + " SHOW MESSAGE");
            message.SetActive(true);
        }
        else
        {
            message.SetActive(false);
        }
    }
    public void OpenDoor()
    {
        doorOpened = true;
        message.SetActive(false);
    }
}