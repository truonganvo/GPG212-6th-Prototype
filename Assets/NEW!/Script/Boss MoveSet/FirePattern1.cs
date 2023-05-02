using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePattern1 : MonoBehaviour
{
    public GameObject bulletPrefab; // assign the bullet prefab in the Inspector
    public float bulletSpeed = 10f; // adjust the bullet speed in the Inspector
    public float fireRate = 0.5f; // adjust the fire rate in the Inspector

    private float timeSinceLastFire = 0f;

    private void Update()
    {
        timeSinceLastFire += Time.deltaTime;
        if (timeSinceLastFire >= fireRate)
        {
            // spawn a new bullet at the position of this object
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // calculate a random direction in which to shoot the bullet
            Vector2 randomDirection = Random.insideUnitCircle.normalized;

            // get the rigidbody component of the bullet
            Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();

            // set the velocity of the bullet in the random direction with the specified speed
            bulletRigidbody.velocity = randomDirection * bulletSpeed;

            timeSinceLastFire = 0f;
        }
    }
}
