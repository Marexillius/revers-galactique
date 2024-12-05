using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesSpawner : MonoBehaviour
{

    public GameObject secondWave;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gameObject.tag == "AccessCard")
        {
            moreEnemies();
            
        }
    }

    public void moreEnemies()
    {
        secondWave.SetActive(true);
    }
}
