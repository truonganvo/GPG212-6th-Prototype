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
    private bool secondStage = false;

    public bool canBeDamaged;

    private void Start()
    {
        healthBarSlider.SetMaxHealth(bossMaxHealth);
        bossHealth = bossMaxHealth;
        canBeDamaged = false;
        if (canBeDamaged == false)
        {
            Invoke("MakeBossAbleToBeDamaged", 5f);
            Debug.Log("MakeBossAbleToBeDamaged");
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
            secondStage= true;
        }

        if (bossHealth <= 50)
        {
            moveset2.SetActive(false);
            canvas3.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canBeDamaged == false) return;

        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (!secondStage)
            {
                bossHealth -= 10;
            }
            if (secondStage)
            {
                bossHealth -= 20;
            }

            healthBarSlider.SetHealth(bossHealth);

        }
    }

    public void SecondStage()
    {
        moveset2.SetActive(true);
    }

    public void MakeBossAbleToBeDamaged()
    {
        canBeDamaged = true;
        Debug.Log("Take no damage");
    }
}
