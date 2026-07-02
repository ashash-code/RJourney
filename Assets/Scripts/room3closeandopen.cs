using UnityEngine;

public class room3doorcloseandopen: MonoBehaviour
{
    public float openAngle = 90f;
    public float speed = 3f;

    private Quaternion closedRot;
    private Quaternion openRot;
    private bool open = false;

    void Start()
    {
        closedRot = transform.localRotation;
        openRot = Quaternion.Euler(0, openAngle, 0) * closedRot;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            open = !open;

        transform.localRotation = Quaternion.Lerp(
            transform.localRotation,
            open ? openRot : closedRot,
            Time.deltaTime * speed
        );
    }
}