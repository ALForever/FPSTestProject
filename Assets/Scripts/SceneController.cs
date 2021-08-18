using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;
    void Update()
    {        
        if (_enemy == null)
        {
            EnemySpawner(ref _enemy, enemyPrefab);
        }
        
    }
    private void EnemySpawner(ref GameObject enemy, GameObject enemyPrefab)
    {        
        enemy = Instantiate(enemyPrefab) as GameObject;
        enemy.transform.position = new Vector3(0, 1, 0);
        float angle = Random.Range(0, 360);
        enemy.transform.Rotate(0, angle, 0);        
    }
}
