using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationController : MonoBehaviour
{

    private bool HasCard = false;


    public void openSampleDoors()
    {
        gameObject.GetComponent<Animator>().Play("simpleAssets_door_opens");
    }

    public void closeSampleDoors()
    {
        gameObject.GetComponent<Animator>().Play("simpleAssets_door_close");
    }

    public void openLargeDoors()
    {
        gameObject.GetComponent<Animator>().Play("largeDoor_Opens");
    }

    public void closeLargeDoors()
    {
        gameObject.GetComponent<Animator>().Play("largeDoor_Closes");
    }

    public void endDoor()
    {
        if (HasCard)
        {
            gameObject.GetComponent<Animator>().Play("simpleAssets_door_close");
        }
        else
        {
            //play sound to say refused
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "accessCard")
        {
            HasCard = true;
        }
    }
}
