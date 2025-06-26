using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 30f;
    public Transform player;

    public List<GameObject> spawnedEnemies = new List<GameObject>();
    private bool isSpawning = true;

    
    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 5f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (!isSpawning || GameManager.instance == null || GameManager.instance.IsGameOver() || player == null)
            return;

        Vector3 spawnPos = new Vector3(0, player.position.y, player.position.z + 150f);

        GameObject enemy = Instantiate(enemyPrefab);
        enemy.SetActive(true);
        enemy.transform.position = spawnPos;
        spawnedEnemies.Add(enemy);
    }

    public void StopAndClearEnemies()
    {
        isSpawning = false;

        foreach (GameObject enemy in spawnedEnemies)
        {
            if (enemy != null)
                Destroy(enemy);
        }

        spawnedEnemies.Clear();
    }

}