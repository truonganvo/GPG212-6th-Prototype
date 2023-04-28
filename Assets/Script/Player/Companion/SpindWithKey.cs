using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpindWithKey : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            gameObject.transform.Rotate(0f, 0f, 10f * Time.deltaTime * 10f);
        }

        if (Input.GetKey(KeyCode.L))
        {
            gameObject.transform.Rotate(0f, 0f, -10f * Time.deltaTime * 10f);
        }
    }
}
