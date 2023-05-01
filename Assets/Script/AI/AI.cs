using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] ParticleSystem deathVFX;
    private Rigidbody2D rb;
    public int health = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //If it move out of screen boundaries then destroy itself
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.x < 0 || screenPosition.x > Screen.width || screenPosition.y < 0 || screenPosition.y > Screen.height)
        {
            Destroy(gameObject);
        }

        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
        Instantiate(deathVFX, gameObject.transform.position, Quaternion.identity);
        Debug.Log("DIE!");
    }
}
