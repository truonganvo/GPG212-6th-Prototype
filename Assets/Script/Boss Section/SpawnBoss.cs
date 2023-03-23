using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    [SerializeField] Timer timing;
    [SerializeField] GameObject enableBossPrefab;

    public List<GameObject> objectsToDisable;

    public void DisableAllObjects()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
    }

    private void Update()
    {
        if (timing.timeValue <= 0)
        {
            enableBossPrefab.SetActive(true);
            DisableAllObjects();
        }
    }
}
