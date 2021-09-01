using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()
    {        
        Animator enemyAnimator = GetComponentInParent<Animator>();
        enemyAnimator.StopPlayback();




        WanderingAI behavior = GetComponentInParent<WanderingAI>();        

        if (behavior != null)
        {
            behavior.SetAlive(false);
        }

        StartCoroutine(Die());        
    }
    private IEnumerator Die()
    {
        Animator enemyAnimator = GetComponentInParent<Animator>();
        enemyAnimator.SetTrigger("enemy_death");
        Animation enemyDeathAnimation = GetComponentInParent<Animation>();        
        yield return new WaitForSeconds(enemyDeathAnimation.clip.length);
        Destroy(transform.parent.gameObject);
    }
}
