using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] Slider HPSlider;

    // 100 / 100 = 1 
    // 90 / 100 = 0.9 
    public void UpdateHP(float health,float maxHealth)
    {
        HPSlider.value = health / maxHealth;
    }


}
