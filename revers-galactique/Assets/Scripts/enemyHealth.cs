using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    int healthPoints = 2;

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

        if (healthPoints == 0)
        {
            // Death sequence here
        }
    }
}
