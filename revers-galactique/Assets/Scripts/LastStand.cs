using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastStand : MonoBehaviour
{
    public GameObject waves1;
    public GameObject waves2;
    public GameObject door;

    private void Update()
    {
        checkEnemies();
    }

    private void checkEnemies()
    {
        if (waves2.transform.childCount <= 0)
        {
            door.GetComponent<BoxCollider>().enabled = true;
        }
        else if (waves1.transform.childCount <= 0)
        {
            waves2.SetActive(true);
        }
    }
}
