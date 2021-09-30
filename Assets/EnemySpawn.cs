using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public Transform[] spawnPoints;
    public float spawnTime = 5f;
    private void Update()
    {
        SpawnEnemy();
    }
    public IEnumerator SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoints[0].position, Quaternion.LookRotation(player.position));
        yield return new WaitForSeconds(spawnTime);
    }    
}
