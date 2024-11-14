using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    int healthPoints = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemyAttack")
        {
            healthPoints--;
            other.gameObject.SetActive(false);
        }

        if (healthPoints == 0)
        {
            // Death sequence here
        }
    }
}
