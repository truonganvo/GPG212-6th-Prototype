using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Status : MonoBehaviour
{
    [SerializeField] int maxhealth = 100;
    [SerializeField] int damageAmount = 5;
    public int currentHealth;
    [SerializeField] TextMeshProUGUI healthText;

    //health slider & change colour
    public Slider healthSlider;
    public Gradient gradient;
    public Image fill;

    //Trigger to take more damage during Healing
    private bool canTakeDamage = true;
    private bool increasedDamage = false;
    [SerializeField] GameObject healIndicate;

    //Delay Healing
    public KeyCode H;
    private float cooldownTime = 10f;
    private bool isCoolDown = false;



    private void Start()
    {
        currentHealth = maxhealth;
        SetMaxHealth(maxhealth);
    }

    private void Update()
    {
        healthText.text = currentHealth.ToString();
        if (Input.GetKey(H) && !isCoolDown)
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
            SceneManager.LoadScene("GameOverScene");
            // Optionally, you could restart the game or take other actions here.
        }
    }

    //Increase Damage taken
    private IEnumerator IncreaseDamage()
    {
        increasedDamage = true;
        healIndicate.SetActive(true);
        Debug.Log("Increase Damage taken");
        yield return new WaitForSeconds(10f);
        healIndicate.SetActive(false);
        increasedDamage = false;
    }

    private IEnumerator KeyCooldownCoroutine()
    {
        yield return new WaitForSeconds(cooldownTime);
        isCoolDown = false;
    }

    //Heal
    public void Heal()
    {
        if (currentHealth < maxhealth)
        {
            isCoolDown = true;
            currentHealth += 15;
            if (currentHealth > maxhealth)
            {
                currentHealth = maxhealth;
                Debug.Log("Max Health already");
            }
            StartCoroutine(IncreaseDamage());
            StartCoroutine(KeyCooldownCoroutine());
        }
    }

}
