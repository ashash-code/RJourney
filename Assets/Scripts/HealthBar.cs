using UnityEngine;
using UnityEngine.UI;
using TMPro;

// eto yung last

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public TMP_Text healthCounter;
    public GameObject playerState;

    private float currentHealth;
    private float maxHealth;

    void Start()
    {
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }
    }

    void Update()
    {
        if (playerState == null)
        {
            return;
        }

        PlayerState player = playerState.GetComponent<PlayerState>();

        if (player == null)
        {
            return;
        }

        currentHealth = player.currentHealth;
        maxHealth = player.maxHealth;

        float fillValue = currentHealth / maxHealth;

        slider.value = fillValue;

        healthCounter.text = Mathf.RoundToInt(currentHealth) + " / " + Mathf.RoundToInt(maxHealth);
    }
}