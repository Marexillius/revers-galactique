using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastStand : MonoBehaviour
{
    public GameObject waves1;
    public GameObject waves2;

    private void Update()
    {
        checkEnemies();
    }

    private void checkEnemies()
    {
        if (waves1.transform.childCount <= 0)
        {
            waves2.SetActive(true);
        }
    }
}
