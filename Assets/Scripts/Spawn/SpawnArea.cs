using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea
{
    private float XMaxBound;
    private float XMinBound;
    private float ZMaxBound;
    private float ZMinBound;

    private float xRandomSpawnPoint { get; set; }
    private float zRandomSpawnPoint { get; set; }

    public SpawnArea(Collider floorBounds)
    {
        XMaxBound = floorBounds.bounds.max.x;
        XMinBound = floorBounds.bounds.min.x;
        ZMaxBound = floorBounds.bounds.max.z;
        ZMinBound = floorBounds.bounds.min.z;
    }
    
    public Vector3 GetRandomSpawnPoint()
    {
        xRandomSpawnPoint = Random.Range(XMinBound, XMaxBound);
        zRandomSpawnPoint = Random.Range(ZMinBound, ZMaxBound);
        return new Vector3(xRandomSpawnPoint, 0, zRandomSpawnPoint);
    }

    public void UpdateAreaBounds(Collider floorBounds)
    {
        XMaxBound = floorBounds.bounds.max.x;
        XMinBound = floorBounds.bounds.min.x;
        ZMaxBound = floorBounds.bounds.max.z;
        ZMinBound = floorBounds.bounds.min.z;
    }
}
