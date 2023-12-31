using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This class update the healthbar of the player within ui
 */
public class HealthBarPlayer : MonoBehaviour
{
   
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    

    public void SetMaxHealth()
    {
        slider.maxValue = PlayerStats.instance.maxHealth;
        slider.value = PlayerStats.instance.playerHealth;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(float playerHealth)
    {
    
     slider.value = PlayerStats.instance.playerHealth;
     fill.color = gradient.Evaluate(slider.normalizedValue);
    }



}
