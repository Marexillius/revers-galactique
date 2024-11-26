using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lineOfSightDetector : MonoBehaviour
{
    public GameObject enemy;
    private EnemyAINodeArea isDetected;
    private void Start()
    {
        isDetected = enemy.GetComponent<EnemyAINodeArea>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isDetected.lineOfSight = true;
        } else
        {
            isDetected.lineOfSight = false;
        }
    }
}
