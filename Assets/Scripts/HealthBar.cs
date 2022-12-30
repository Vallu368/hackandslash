using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    private PlayerStats stats;
    void Start()
    {
        slider = this.gameObject.GetComponent<Slider>();
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        slider.maxValue = stats.maxHealth;
    }

    private void Update()
    {
        slider.value = stats.currentHealth;
    }
}
