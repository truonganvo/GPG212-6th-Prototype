using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] AI die;
    private int bulletDamage = 10;


    public float movementSpeed = 25f; // adjust the movement speed in the Inspector
    public float destroyDistance = 0.1f; // adjust the distance at which to destroy the object in the Inspector
    [SerializeField] Transform playerTransform; // the transform component of the player object

    [SerializeField] Shooting isThrowYet;
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
        }

        if (other.transform.CompareTag("Player"))
        {
            isThrowYet.isThrowYet = false;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (isThrowYet.isThrowYet)
        {
            Invoke("ReturnToPlayer", 2.65f);
        }
    }
    public void ReturnToPlayer()
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        rb.velocity = direction * movementSpeed;
        isThrowYet.companion.SetActive(true);
    }
}
