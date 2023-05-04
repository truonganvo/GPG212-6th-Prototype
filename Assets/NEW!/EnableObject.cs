using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : MonoBehaviour
{
    [SerializeField] GameObject enableObject;

    public void PressToEnable()
    {
        enableObject.SetActive(true);
    }
}
