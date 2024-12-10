using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastStand : MonoBehaviour
{
    public GameObject waves1;
    public GameObject waves2;
    public GameObject door;
    public GameObject DoorLight;

    public AudioClip enemySpawn;
    public AudioSource boomBox;

    private void Start()
    {
        boomBox = GetComponent<AudioSource>();
    }

    private void Update()
    {
        checkEnemies();
    }

    private void checkEnemies()
    {
        if (waves2.transform.childCount <= 0)
        {
            door.GetComponent<BoxCollider>().enabled = true;
            DoorLight.GetComponent<Light>().intensity = 2;
        }
        else if (waves1.transform.childCount <= 0)
        {
            boomBox.PlayOneShot(enemySpawn, 0.5f);
            waves2.SetActive(true);
        }
    }
}
