using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationController : MonoBehaviour
{

    private static bool HasCard = false;

    public AudioClip accessDenied;
    public AudioClip openSound;
    public AudioSource boomBox;

    private void Start()
    {
        boomBox = GetComponent<AudioSource>();
    }

    public void openSampleDoors()
    {
        gameObject.GetComponent<Animator>().Play("simpleAssets_door_opens");
        boomBox.PlayOneShot(openSound, 0.5f);
    }

    public void closeSampleDoors()
    {
        gameObject.GetComponent<Animator>().Play("simpleAssets_door_close");
        boomBox.PlayOneShot(openSound, 0.5f);
    }

    public void openLargeDoors()
    {
        gameObject.GetComponent<Animator>().Play("largeDoor_Opens");
        boomBox.PlayOneShot(openSound, 0.5f);
    }

    public void closeLargeDoors()
    {
        gameObject.GetComponent<Animator>().Play("largeDoor_Closes");
        boomBox.PlayOneShot(openSound, 0.5f);
    }

    public void endDoor()
    {
        if (HasCard == true)
        {
            gameObject.GetComponent<Animator>().Play("simpleAssets_door_opens");
            boomBox.PlayOneShot(openSound, 0.5f);
        }
        else
        {
            Debug.Log("get cards lmao");
            //play sound to say refused
            boomBox.PlayOneShot(accessDenied, 1f);
        }
    }

    public GameObject Door;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Door)
        {
            Door.GetComponent<Animator>().Play("simpleAssets_door_close");
            boomBox.PlayOneShot(openSound, 0.5f);
        } 
        else if (other.tag == "Player" && gameObject.tag == "Door_Large" )
        {
            gameObject.GetComponent<Animator>().Play("largeDoor_Opens");
            boomBox.PlayOneShot(openSound, 0.5f);
        } 
        else if (other.tag == "Player" && gameObject.tag == "AccessCard")
        {
            Debug.Log("got card");
            HasCard = true;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && gameObject.tag == "Door_Large")
        {
            gameObject.GetComponent<Animator>().Play("largeDoor_Closes");
            boomBox.PlayOneShot(openSound, 0.5f);
        }
    }

    public void unlockCityDoor()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
