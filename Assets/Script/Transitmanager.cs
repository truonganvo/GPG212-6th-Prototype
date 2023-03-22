using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitmanager : MonoBehaviour
{
    [SerializeField] GameObject enableAnObject;
    [SerializeField] GameObject disableAnObject;

    public void EnableAnObject()
    {
        enableAnObject.SetActive(true);
        disableAnObject.SetActive(false);
    }
}
