using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CaloriesBar : MonoBehaviour
{
    public Slider slider;
    public TMP_Text caloriesCounter;
    public GameObject playerState;

    private PlayerState player;

    private void Start()
    {
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }

        if (playerState != null)
        {
            player = playerState.GetComponent<PlayerState>();
        }

        if (slider != null)
        {
            slider.minValue = 0f;
            slider.maxValue = 1f;
        }
    }

    private void Update()
    {
        if (player == null)
            return;

        if (player.maxCalories <= 0f)
            return;

        slider.value =
            player.currentCalories / player.maxCalories;

        if (caloriesCounter != null)
        {
            caloriesCounter.text =
                Mathf.RoundToInt(player.currentCalories)
                + " / "
                + Mathf.RoundToInt(player.maxCalories);
        }
    }
}
