using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CaloriesBar : MonoBehaviour
{


    public Slider slider;
    public TMP_Text caloriesCounter;
    public GameObject playerState;

    private float currentCalories;
    private float maxCalories;

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

        currentCalories = player.currentCalories;
        maxCalories = player.maxCalories;

        float fillValue = currentCalories / maxCalories;

        slider.value = fillValue;

        caloriesCounter.text = Mathf.RoundToInt(currentCalories) + " / " + Mathf.RoundToInt(maxCalories);
    }








    
        
    }

    // Update is called once per frame
  
