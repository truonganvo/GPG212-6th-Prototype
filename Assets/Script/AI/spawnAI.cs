using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAI : MonoBehaviour
{
    [SerializeField] GameObject aiPrefab;
    [SerializeField] float respawnTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemyWave());
    }

    private void SpawnEnemy()
    {
        GameObject ai = Instantiate(aiPrefab) as GameObject;
        ai.transform.position = new Vector2(1025, Random.Range(380, 440));
    }    
    IEnumerator enemyWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
