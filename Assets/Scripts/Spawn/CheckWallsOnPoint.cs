using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWallsOnPoint
{
    private Collider[] childrenWalls;
    
    public CheckWallsOnPoint(Transform parentWall)
    {
        childrenWalls = parentWall.GetComponentsInChildren<Collider>();
    }

    public bool DoesWallContainPoint(Vector3 point)
    {
        foreach (Collider bound in childrenWalls)
        {
            if (bound.bounds.Contains(point))
                return true;
        }
        return false;
    }
}
