using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int powerLevel;
    public int maxHealth = 100;
    public int currentHealth;
    public int maxEnergy;
    public int currentEnergy;
    public int energyDrain;

    private FlyBehaviour fly;
    private int nextUpdate;
    void Start()
    {
        currentHealth = maxHealth;
        currentEnergy = maxEnergy;
        fly = this.gameObject.GetComponent<FlyBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextUpdate)
        {
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }

    }
    void UpdateEverySecond()
    {
        if (fly.fly) //drain energy when flying
        {
            currentEnergy = currentEnergy - energyDrain;
        }
        if (!fly.fly) //recover energy when not flying
        {
            if (currentEnergy < maxEnergy)
            {
                currentEnergy++;
            }
        }
    }
}
