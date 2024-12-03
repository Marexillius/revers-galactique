using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamiteBoom : MonoBehaviour
{
    public GameObject broken_rock;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "break")
        {
            collision.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Nothing happened");
        }
    }
}
