using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBoss : MonoBehaviour
{
   
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    

    public void SetMaxHealth()
    {
        slider.maxValue = BossStats.instance.bossHealth;
        slider.value = BossStats.instance.bossHealth;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(float playerHealth)
    {
    
     slider.value = BossStats.instance.bossHealth;
     fill.color = gradient.Evaluate(slider.normalizedValue);
    }



}
