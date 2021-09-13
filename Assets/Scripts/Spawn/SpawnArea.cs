using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea
{
    private float _XMaxBound;
    private float _XMinBound;
    private float _ZMaxBound;
    private float _ZMinBound;

    private float _xRandomSpawnPoint { get; set; }
    private float _zRandomSpawnPoint { get; set; }

    public SpawnArea(Collider floorBounds)
    {
        _XMaxBound = floorBounds.bounds.max.x;
        _XMinBound = floorBounds.bounds.min.x;
        _ZMaxBound = floorBounds.bounds.max.z;
        _ZMinBound = floorBounds.bounds.min.z;
    }
    
    public Vector3 GetRandomSpawnPoint()
    {
        _xRandomSpawnPoint = Random.Range(_XMinBound, _XMaxBound);
        _zRandomSpawnPoint = Random.Range(_ZMinBound, _ZMaxBound);
        return new Vector3(_xRandomSpawnPoint, 0, _zRandomSpawnPoint);
    }

    public void UpdateAreaBounds(Collider floorBounds)
    {
        _XMaxBound = floorBounds.bounds.max.x;
        _XMinBound = floorBounds.bounds.min.x;
        _ZMaxBound = floorBounds.bounds.max.z;
        _ZMinBound = floorBounds.bounds.min.z;
    }
}
