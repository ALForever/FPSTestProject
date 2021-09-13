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

    private ObjectPoolMono<EnemyAI> _enemyPool;
    private CheckWallsOnPoint _innerWalls;
    private SpawnArea _currentSpawnArea;

    private void Start()
    {
        _enemyPool = new ObjectPoolMono<EnemyAI>(enemyPrefab, poolCount, transform, true);
        _enemyPool.autoExpand = autoExpand;
        _innerWalls = new CheckWallsOnPoint(parentWall);
        _currentSpawnArea = new SpawnArea(floorBounds);

        foreach (EnemyAI enemy in _enemyPool.GetAllActiveElemets())
        {
            enemy.transform.position = GetCorrectSpawnPoint();
        }        
    }
    private Vector3 GetCorrectSpawnPoint()
    {
        Vector3 correctSpawnPoint;
        do
        {
            correctSpawnPoint = _currentSpawnArea.GetRandomSpawnPoint();
        }
        while (_innerWalls.DoesWallContainPoint(correctSpawnPoint));
        return correctSpawnPoint;
    }
}
