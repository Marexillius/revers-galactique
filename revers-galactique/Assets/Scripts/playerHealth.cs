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

    public AudioClip hurtSound;
    public AudioClip deathSound;
    public AudioSource boomBox;

    private void Start()
    {
        boomBox = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (healthPoints == 0)
        {
            boomBox.PlayOneShot(deathSound, 0.5f);
            deathScreen();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
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
        boomBox.PlayOneShot(hurtSound, 0.5f);
        Debug.Log(healthPoints);
        healthPointsUI[healthPoints].SetActive(false);
        yield return new WaitForSeconds(3);
        hasIframes = false;
        yield break;
    }
}
