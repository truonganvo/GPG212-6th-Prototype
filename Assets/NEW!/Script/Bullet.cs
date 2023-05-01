using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] AI die;

    private int bulletDamage = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            AI enemy = other.gameObject.GetComponent<AI>();
            enemy.health -= bulletDamage;
            Destroy(gameObject);
        }
    }
}
