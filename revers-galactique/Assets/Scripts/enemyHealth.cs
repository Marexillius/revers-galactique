using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int healthPoints = 1;
    public GameObject container;
    private EnemyAINodeArea isDetected;

    private bool hasIframes = false;

    public AudioClip enemyDeath;
    public AudioClip enemyDamaged;
    public AudioSource boomBox;



    private void Start()
    {
        isDetected = container.GetComponent<EnemyAINodeArea>();
        boomBox = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (healthPoints <= 0)
        {
            boomBox.PlayOneShot(enemyDeath, 0.3f);
            StartCoroutine(DeathSequence());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(healthPoints);
        if (other.tag == "ballPlayer"  && hasIframes == false)
        {
            StartCoroutine(DamageSequence());
        } else if (other.tag == "racket" || other.tag == "throwable")
        {
            StartCoroutine(StunSequence());
        } else if (other.tag == "wall")
        {
            isDetected.lineOfSight = false;
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

    private IEnumerator DamageSequence()
    {
        healthPoints--;
        hasIframes = true;
        boomBox.PlayOneShot(enemyDamaged, 0.3f);
        isDetected.lineOfSight = true;
        yield return new WaitForSeconds(2);
        hasIframes = false;
        yield break;
    }

}
