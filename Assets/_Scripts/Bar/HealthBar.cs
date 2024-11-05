using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public Text healthText;
    
    public void UpdateHealth(float healthNow, float healthMax){
        this.healthBar.fillAmount = healthNow / healthMax;
        this.healthText.text = "" + healthNow;
    }
}
