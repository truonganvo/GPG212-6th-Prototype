using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform followPlayer;
    [SerializeField] float speed = 5;


    // Update is called once per frame
    void Update()
    {
        Vector3 direction = followPlayer.position - transform.position;

        // Normalize the direction so that it has a length of 1
        direction.Normalize();

        // Move the object towards the player at the specified speed
        transform.position += direction * speed * Time.deltaTime;
    }
}
