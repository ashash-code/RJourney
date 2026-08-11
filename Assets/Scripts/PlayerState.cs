using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerState : MonoBehaviour
{
    public static PlayerState Instance { get; private set; }

    // player health
    public float currentHealth;
    public float maxHealth;

    // player calories/food
    public float currentCalories;
    public float maxCalories;

    float distanceTravelled = 0;
    Vector3 lastPosition;

    public GameObject playerBody;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        currentCalories = maxCalories;

        lastPosition = playerBody.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += Vector3.Distance(playerBody.transform.position, lastPosition);
        lastPosition = playerBody.transform.position;

        //eto kung gusto mo mabagan ng calories yung player mo
        if (distanceTravelled >= 20)
        {
            distanceTravelled = 0;
            currentCalories -= 1f;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            currentHealth -= 10f;
        }
    }
}