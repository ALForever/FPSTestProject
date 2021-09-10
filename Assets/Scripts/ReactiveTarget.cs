using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField] private AnimationClip enemyDeathAnimation;
    public void ReactToHit()
    {
        EnemyAI behavior = GetComponentInParent<EnemyAI>();        

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
        yield return new WaitForSeconds(enemyDeathAnimation.length);
        Destroy(transform.parent.gameObject);
    }
}
