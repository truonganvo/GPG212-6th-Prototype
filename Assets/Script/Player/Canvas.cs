using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    public List<GameObject> objectsToEnable;
    public float enableDelay;
    public float disableDelay;
    public float nextEnableDelay;
    public GameObject disableTheList;

    void Start()
    {
        // Enable the first object in the list after the specified delay
        Invoke("EnableObject", enableDelay);
    }

    void EnableObject()
    {
        foreach (GameObject obj in objectsToEnable)
        {
            obj.SetActive(false);
        }

        // Enable the first object in the list
        GameObject objToEnable = objectsToEnable[0];
        objToEnable.SetActive(true);

        // Remove the first object in the list
        objectsToEnable.RemoveAt(0);

        // Wait for the specified delay before disabling the object
        Invoke("DisableObject", nextEnableDelay);
    }

    void DisableObject()
    {
        // Check if the list is empty
        if (objectsToEnable.Count == 0)
        {
            Invoke("DisableTheList", 0f);
            return;
        }
        // Disable the object
        GameObject objToDisable = objectsToEnable[0];
        objToDisable.SetActive(false);

        // Wait for the specified delay before enabling the next object
        Invoke("EnableObject", disableDelay);
    }

    void DisableTheList()
    {
        disableTheList.SetActive(false);
    }
}
