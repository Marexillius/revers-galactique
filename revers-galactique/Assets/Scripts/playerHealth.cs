using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public int healthPoints = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemyAttack")
        {
            healthPoints--;
            /*other.transform.localScale = Vector3.one;
            Destroy(other);*/
            Debug.Log(healthPoints);
        }
        else if (other.tag == "Enemy")
        {
            healthPoints--;
            Debug.Log(healthPoints);
        }

        if (healthPoints == 0)
        {
            // Death sequence here
            Debug.Log("DEATH");
            deathScreen();
        }
    }

    public void deathScreen()
    {
        Debug.Log("test");
        SceneManager.LoadScene("Level_Start");
    }
}
