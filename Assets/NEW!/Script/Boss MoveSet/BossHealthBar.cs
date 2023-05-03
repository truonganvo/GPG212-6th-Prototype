using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] Slider bossHealthBarSlider;

    public void SetMaxHealth(int maxHealth)
    {
        bossHealthBarSlider.maxValue= maxHealth;
        bossHealthBarSlider.value = maxHealth;
    }

    public void SetHealth(int health)
    {
        bossHealthBarSlider.value = health;
    }
    // Start is called before the first frame update
    void Start()
    {
        bossHealthBarSlider.GetComponent<Slider>();
    }
}
