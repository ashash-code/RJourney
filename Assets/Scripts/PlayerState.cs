using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static PlayerState Instance { get; private set; }

    [Header("Player Health")]
    public float currentHealth;
    public float maxHealth = 100f;

    [Header("Player Calories")]
    public float currentCalories;
    public float maxCalories = 100f;

    [Header("Movement")]
    public GameObject playerBody;

    private float distanceTravelled = 0f;
    private Vector3 lastPosition;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        currentCalories = maxCalories;

        if (playerBody != null)
            lastPosition = playerBody.transform.position;
        else
            lastPosition = transform.position;
    }

    private void Update()
    {
        Vector3 currentPosition;

        if (playerBody != null)
            currentPosition = playerBody.transform.position;
        else
            currentPosition = transform.position;

        distanceTravelled += Vector3.Distance(
            currentPosition,
            lastPosition
        );

        lastPosition = currentPosition;

        // Every 20 distance = -1 calorie
        if (distanceTravelled >= 20f)
        {
            distanceTravelled = 0f;
            currentCalories -= 1f;

            currentCalories = Mathf.Clamp(
                currentCalories,
                0f,
                maxCalories
            );
        }

        // Test damage
        if (Input.GetKeyDown(KeyCode.N))
        {
            currentHealth -= 10f;
        }
    }

    public void AddCalories(float amount)
    {
        currentCalories += amount;

        currentCalories = Mathf.Clamp(
            currentCalories,
            0f,
            maxCalories
        );
    }
}
