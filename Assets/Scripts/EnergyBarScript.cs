using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarScript : MonoBehaviour
{
    private Slider slider;
    private PlayerStats stats;
    void Start()
    {
        slider = this.gameObject.GetComponent<Slider>();
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        slider.maxValue = stats.maxEnergy;
    }

    private void Update()
    {
        slider.value = stats.currentEnergy;
    }

}
