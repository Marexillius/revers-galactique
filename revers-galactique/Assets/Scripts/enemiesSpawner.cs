using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesSpawner : MonoBehaviour
{

    public GameObject secondWave;

    public AudioClip enemySpawn;
    public AudioSource boomBox;

    private void Start()
    {
        boomBox = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gameObject.tag == "AccessCard")
        {
            moreEnemies();
            
        }
    }

    public void moreEnemies()
    {
        boomBox.PlayOneShot(enemySpawn, 0.4f);
        secondWave.SetActive(true);
    }
}
