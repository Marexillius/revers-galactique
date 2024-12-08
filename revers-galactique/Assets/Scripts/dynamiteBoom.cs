using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamiteBoom : MonoBehaviour
{
    public GameObject broken_rock;
    public GameObject dynamite;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "break")
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    public void spawnBoom()
    {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.transform.position = new Vector3(dynamite.transform.position.x, dynamite.transform.position.y, dynamite.transform.position.z);
    }
}
