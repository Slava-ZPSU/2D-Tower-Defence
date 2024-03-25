using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Visible fields
    [SerializeField]
    private List<EnemyController> enemys;
    [SerializeField]
    private Transform enemysContainer;
    [SerializeField]
    private List<Transform> wayPoints;

    // Invisible fields
    private Vector2 spawnPoint;
    private float timer = 0.0f;
    private float spawnDuration = 10f;

    private void Start()
    {
        spawnPoint = transform.position;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (timer < spawnDuration) {
            return;
        }

        var enemy = Instantiate(enemys[Random.Range(0, enemys.Count)], spawnPoint, transform.rotation);
        enemy.transform.SetParent(enemysContainer);
        enemy.FillWayPoints(wayPoints);
        timer = 0.0f;
    }
}
