using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetmaxHealth(int health)
    {
        //slider.maxValue = 400;
        slider.value = health;
    }
    private void Start()
    {
        slider.maxValue = 100;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
   