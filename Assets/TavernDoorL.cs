using UnityEngine;

public class TavernDoorL : MonoBehaviour
{
    public void OpenDoor()
    {
        transform.Rotate(0, -90, 0);
    }
}