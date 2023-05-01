using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] int bossHealth;
    [SerializeField] GameObject opSpawn;

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
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            bossHealth -= 10;
        }
    }
}
