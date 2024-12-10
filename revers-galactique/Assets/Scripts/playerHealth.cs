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
            StartCoroutine(deathScreen());
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

    private IEnumerator deathScreen()
    {
        Debug.Log("DEATH");
        boomBox.PlayOneShot(deathSound, 0.5f);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Level_Death");
        yield break;
    }

    private IEnumerator healthCounter()
    {
        hasIframes = true;
        healthPoints--;
        boomBox.PlayOneShot(hurtSound, 0.7f);
        Debug.Log(healthPoints);
        healthPointsUI[healthPoints].SetActive(false);
        yield return new WaitForSeconds(3);
        hasIframes = false;
        yield break;
    }

}
