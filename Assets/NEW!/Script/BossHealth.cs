using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] int bossHealth;
    [SerializeField] GameObject opSpawn;
    [SerializeField] GameObject moveset1;
    [SerializeField] GameObject moveset2;

    private void Update()
    {
        if (bossHealth == 0)
        {
           Destroy(gameObject);
           opSpawn.SetActive(false);
        }

        if (bossHealth == 50)
        {
            GetComponent<Animator>().SetBool("Second Stage", true);
            moveset1.SetActive(false);
            Invoke("SecondStage", 5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            bossHealth -= 10;
        }
    }

    public void SecondStage()
    {
        moveset2.SetActive(true);
    }
}
