using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public Transform[] spawnPoints;
    public float timeBetweenSpawn = 5f;
    private float spawnTime = 5f;
    private void Update()
    {
        if (spawnTime <= 0f)
        {
            StartCoroutine(SpawnEnemy());
            spawnTime = timeBetweenSpawn;
        }
        spawnTime -= Time.deltaTime;
    }
    public IEnumerator SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoints[Random.Range(0,3)].position, Quaternion.LookRotation(player.position));
        yield return new WaitForSeconds(1f);
    } 
}
