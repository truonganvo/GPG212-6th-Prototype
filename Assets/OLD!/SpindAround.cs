using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpindAround : MonoBehaviour
{
    public Transform centerObject; // The object around which the object will move and spin
    public float radius = 2f; // The radius of the circle
    public float speed = 2f; // The speed at which the object moves around the circle
    public float rotationSpeed = 180f; // The speed at which the object spins around the center object

    private float angle; // The current angle of the object in radians

    void Update()
    {
        //Moving around
        // Calculate the position of the object based on the angle and radius
        float x = centerObject.position.x + radius * Mathf.Cos(angle);
        float y = centerObject.position.y + radius * Mathf.Sin(angle);
        transform.position = new Vector3(x, y, transform.position.z);

        // Increase the angle based on the speed and the elapsed time since the last frame
        angle += speed * Time.deltaTime;

        // If the angle is greater than 2 * Pi radians, reset it to 0
        if (angle > Mathf.PI * 2)
        {
            angle -= Mathf.PI * 2;
        }

        //Rotating
        // Calculate the rotation of the object based on the elapsed time since the last frame
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.RotateAround(centerObject.position, Vector3.forward, rotationAmount);
    }
}
