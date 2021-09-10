using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstaclRange = 5.0f;
    private bool _alive = true;
    [SerializeField] private GameObject firaballPrefab;
    private GameObject _fireball;
    
    void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            Ray ray = new Ray(transform.GetChild(0).position, transform.GetChild(0).forward);            
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if(_fireball == null)
                    {
                        _fireball = Instantiate(firaballPrefab) as GameObject;
                        _fireball.transform.position = transform.GetChild(0).TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.GetChild(0).rotation;
                    }
                }

                else if (hit.distance < obstaclRange && hitObject != _fireball)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }
    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}

