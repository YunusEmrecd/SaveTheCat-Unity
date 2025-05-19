using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform target;
    public float spawnInterval = 1f; // Spawn aralığı
    public float spawnDistance = 10f;

    private float spawnTimer;


    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyPrefab = enemyPrefabs[randomIndex];

        Vector3 spawnPosition = target.position + (Vector3)(Random.insideUnitCircle.normalized * spawnDistance);
        spawnPosition.z = 0;

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        EnemyMover enemyMover = enemy.GetComponent<EnemyMover>();

        if (enemyMover != null)
            enemyMover.speed = 3f;
        {
            if (randomIndex == 0)
            {
                enemyMover.speed = 3f;

            }
            else if (randomIndex == 1)
            {
                enemyMover.speed = 4f;

            }


            enemyMover.Initialize(target);



        }
    }
}



