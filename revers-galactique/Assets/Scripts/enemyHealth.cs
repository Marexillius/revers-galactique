using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int healthPoints = 2;
    public GameObject container;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(healthPoints);
        if (other.tag == "enemyAttack")
        {
            healthPoints--;
            other.gameObject.SetActive(false);
        } else if (other.tag == "ballPlayer")
        {
            healthPoints--;
        } else if (other.tag == "racket")
        {
            // Stun sequence here
        }

        if (healthPoints <= 0)
        {
            StartCoroutine(DeathSequence());
        }
    }

    private IEnumerator DeathSequence()
    {
        // Death sequence here
        Destroy(container.GetComponent<EnemyAI>());
        gameObject.GetComponent<Animator>().Play("ennemi_die_anim");

        yield return new WaitForSeconds(2);

        Destroy(container);

        yield break;
    }
}
