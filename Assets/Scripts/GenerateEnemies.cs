using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerateEnemies : MonoBehaviour
{
    [SerializeField] private GameObject floor;
    [SerializeField] private GameObject enemy;
    private int enemyCount;
    [SerializeField] private int numberOfEnemies;
    [SerializeField] private float floorSurface;
    [SerializeField] private float spawnTimeMin;
    [SerializeField] private float spawnTimeMax;
    private float spawnTime;
    private float xPos;
    private float zPos;
    private float yPos;
   

    void Start()
    {
        enemyCount = 0;
        floorSurface = floor.transform.localScale.z;
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (enemyCount < numberOfEnemies)
        {
            xPos = Random.Range(-transform.localScale.x/2, transform.localScale.x / 2);
            yPos = Random.Range(floorSurface, floorSurface+0.1f);
            zPos = transform.position.z;
            spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            GameObject enemyClone = Instantiate(enemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            enemyClone.transform.localScale = new Vector3(Random.Range(1f, 10f), Random.Range(1f, 10f), Random.Range(1f, 4f));
            yield return new WaitForSeconds(spawnTime);
            enemyCount += 1;
        }
        if (enemyCount == numberOfEnemies)
        {
            yield return new WaitForSeconds(2);
            PlayerManager.victory = true;
        }
    }
}
