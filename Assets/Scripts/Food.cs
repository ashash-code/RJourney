using UnityEngine;

public class Food : MonoBehaviour
{
    public float calories = 20f;

    private void OnMouseDown()
    {
        if (PlayerState.Instance == null)
        {
            Debug.LogError("PlayerState not found!");
            return;
        }

        // Add calories
        PlayerState.Instance.AddCalories(calories);

        // Destroy food
        Destroy(gameObject);
    }
}
