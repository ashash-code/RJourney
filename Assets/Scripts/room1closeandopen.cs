using UnityEngine;

public class room1doorcloseandopen : MonoBehaviour
{
    public float openAngle = 90f;
    public float speed = 3f;
    public float range = 2f;

    private Quaternion closedRot;
    private Quaternion openRot;
    private bool open = false;

    private Transform player;

    void Start()
    {
        closedRot = transform.localRotation;
        openRot = Quaternion.Euler(0, openAngle, 0) * closedRot;

        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player == null) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(player.position, player.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, range))
            {
                if (hit.transform == transform)
                {
                    open = !open;
                }
            }
        }

        transform.localRotation = Quaternion.Lerp(
            transform.localRotation,
            open ? openRot : closedRot,
            Time.deltaTime * speed
        );
    }
}