using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField] int bossHealth;
    [SerializeField] GameObject moveset1;
    [SerializeField] GameObject moveset2;
    [SerializeField] GameObject canvas2;
    [SerializeField] GameObject canvas3;
    [SerializeField] BossHealthBar healthBarSlider;
    private int bossMaxHealth = 1000;

    public bool isVulnerable;

    private void Start()
    {
        healthBarSlider.SetMaxHealth(bossMaxHealth);
        bossHealth = bossMaxHealth;
        isVulnerable = true;
        if (isVulnerable)
        {
            Invoke("RemoveVulnerable", 5f);
        }
    }

    private void Update()
    {
        if (bossHealth == 0)
        {
           Destroy(gameObject);
        }

        if (bossHealth <= 500)
        {
            GetComponent<Animator>().SetBool("Second Stage", true);
            moveset1.SetActive(false);
            canvas2.SetActive(true);
            Invoke("SecondStage", 5f);
        }

        if (bossHealth <= 30)
        {
            moveset2.SetActive(false);
            canvas3.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isVulnerable) return;

        if (collision.gameObject.CompareTag("Bullet"))
        {
            bossHealth -= 10;
            healthBarSlider.SetHealth(bossHealth);
        }
    }

    public void SecondStage()
    {
        moveset2.SetActive(true);
    }

    public void RemoveVulnerable()
    {
        isVulnerable = false;
    }
}
