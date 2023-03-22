using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    [SerializeField] int maxhealth = 100;
    public int currentHealth;

    //health slider & change colour
    public Slider healthSlider;
    public Gradient gradient;
    public Image fill;


    private void Start()
    {
        currentHealth = maxhealth;
        SetMaxHealth(maxhealth);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Take Damage");
            currentHealth -= 5;
            SetHealth(currentHealth);
            Destroy(collision.gameObject);
        }
    }

    public void SetMaxHealth(int maxhealth)
    {
        healthSlider.value = maxhealth;
        healthSlider.maxValue = maxhealth;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;
        fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }

}
