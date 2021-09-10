using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private EnemyAI enemyPrefab;
    [SerializeField] private Transform parentWall;
    [SerializeField] private Collider floorBounds;
    [SerializeField] private int poolCount = 3;
    [SerializeField] private bool autoExpand = false;

    private ObjectPoolMono<EnemyAI> enemyPool;
    private CheckWallsOnPoint innerWalls;
    private SpawnArea currentSpawnArea;

    private void Start()
    {
        enemyPool = new ObjectPoolMono<EnemyAI>(enemyPrefab, poolCount, transform, true);
        enemyPool.autoExpand = autoExpand;
        innerWalls = new CheckWallsOnPoint(parentWall);
        currentSpawnArea = new SpawnArea(floorBounds);

        foreach (EnemyAI enemy in enemyPool.GetAllActiveElemets())
        {
            enemy.transform.position = GetCorrectSpawnPoint();
        }        
    }
    private Vector3 GetCorrectSpawnPoint()
    {
        Vector3 correctSpawnPoint;
        do
        {
            correctSpawnPoint = currentSpawnArea.GetRandomSpawnPoint();
        }
        while (innerWalls.DoesWallContainPoint(correctSpawnPoint));
        return correctSpawnPoint;
    }
}
