using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    [SerializeField] int maxhealth = 100;
    [SerializeField] int damageAmount = 5;
    public int currentHealth;

    //health slider & change colour
    public Slider healthSlider;
    public Gradient gradient;
    public Image fill;

    //Trigger to take more damage during Healing

    private bool canTakeDamage = true;
    private bool increasedDamage = false;
    [SerializeField] GameObject healIndicate;


    private void Start()
    {
        currentHealth = maxhealth;
        SetMaxHealth(maxhealth);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            Heal();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
            SetHealth(currentHealth);
            Destroy(collision.gameObject);
        }
    }

    //Setting Health
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

    //Take damage
    private void TakeDamage()
    {
        if (increasedDamage == true)
        {
            currentHealth -= damageAmount + 15;
        }
        else
        {
            currentHealth -= damageAmount;
        }

        if (currentHealth <= 0)
        {
            // Player has died
            Debug.Log("Player has died.");
            // Optionally, you could restart the game or take other actions here.
        }
    }

    //Increase Damage taken
    private IEnumerator IncreaseDamage()
    {
        increasedDamage = true;
        Debug.Log("Increase Damage taken");
        yield return new WaitForSeconds(10f);
        increasedDamage = false;
    }

    //Heal
    public void Heal()
    {
        if (currentHealth < maxhealth)
        {
            currentHealth += 10;
            if (currentHealth > maxhealth)
            {
                currentHealth = maxhealth;
                Debug.Log("Max Health already");
            }
            StartCoroutine(IncreaseDamage());
            StartCoroutine(HealthLetter());
        }
    }

    private IEnumerator HealthLetter()
    {
        healIndicate.SetActive(true);
        yield return new WaitForSeconds(10f);
        healIndicate.SetActive(false);
    }

}
