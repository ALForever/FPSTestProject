using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            behavior.SetAlive(false);
        }
        if (gameObject.transform.rotation.x == 0)
        {            
            StartCoroutine(Die());            
        }       
    }
    private IEnumerator Die()
    {
        this.transform.Rotate(-25, 0, 0);        
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);        
    }
}
