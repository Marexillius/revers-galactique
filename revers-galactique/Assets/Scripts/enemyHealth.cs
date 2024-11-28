using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int healthPoints = 2;
    public GameObject container;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(healthPoints);
        if (other.tag == "enemyAttack")
        {
            healthPoints--;
            other.gameObject.SetActive(false);
        } else if (other.tag == "ballPlayer")
        {
            healthPoints--;
        } else if (other.tag == "racket" || other.tag == "throwable")
        {
            StartCoroutine(StunSequence());
        }

        if (healthPoints <= 0)
        {
            StartCoroutine(DeathSequence());
        }
    }

    private IEnumerator DeathSequence()
    {
        // Death sequence here
        Destroy(container.GetComponent<EnemyAINodeArea>());
        gameObject.GetComponent<Animator>().Play("ennemi_die_anim");

        yield return new WaitForSeconds(2);

        Destroy(container);

        yield break;
    }

private IEnumerator StunSequence()
    {
        // Stun sequence here

        container.GetComponent<EnemyAINodeArea>().enabled = false;
        gameObject.GetComponent<Animator>().Play("ennemi_stun_anim");

        yield return new WaitForSeconds(3);

        container.GetComponent<EnemyAINodeArea>().enabled = true;

        yield break;
    }
}
