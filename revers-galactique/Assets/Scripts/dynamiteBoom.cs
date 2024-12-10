using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class dynamiteBoom : MonoBehaviour
{
    public GameObject broken_rock;
    public GameObject dynamite;

    public AudioClip boom;
    public AudioSource boomBox;

    private void Start()
    {
        boomBox = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "break")
        {
            StartCoroutine(DoBoom());
        }
    }

    public void spawnBoom()
    {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.transform.position = new Vector3(dynamite.transform.position.x, dynamite.transform.position.y, dynamite.transform.position.z);
    }

    private IEnumerator DoBoom()
    {
        boomBox.PlayOneShot(boom, 0.7f);
        yield return new WaitForSeconds(1);
        broken_rock.gameObject.SetActive(false);
        gameObject.SetActive(false);
        yield break;
    }
}
