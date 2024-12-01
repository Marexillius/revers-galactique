using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public int healthPoints = 5;
    public GameObject[] healthPointsUI;
    private bool hasIframes = false;

    private void OnTriggerEnter(Collider other)
    {
        if (healthPoints == 0)
        {
            deathScreen();
        }

        if (hasIframes == false)
        {
            if (other.tag == "Enemy" || other.tag == "enemyAttack")
            {
                StartCoroutine(healthCounter());
            }            
        }

    }

    public void deathScreen()
    {
        Debug.Log("DEATH");
        SceneManager.LoadScene("Level_Death");
    }

    private IEnumerator healthCounter()
    {
        hasIframes = true;
        healthPoints--;
        Debug.Log(healthPoints);
        healthPointsUI[healthPoints].SetActive(false);
        yield return new WaitForSeconds(3);
        hasIframes = false;
        yield break;
    }
}
