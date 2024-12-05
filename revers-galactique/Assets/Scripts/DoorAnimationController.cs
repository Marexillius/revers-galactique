using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationController : MonoBehaviour
{

    private static bool HasCard = false;

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
        if (HasCard == true)
        {
            gameObject.GetComponent<Animator>().Play("simpleAssets_door_opens");
        }
        else
        {
            Debug.Log("get cards lmao");
            //play sound to say refused
        }
    }

    public GameObject Door;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Door)
        {
            Door.GetComponent<Animator>().Play("simpleAssets_door_close");
        } 
        else if (other.tag == "Player" && gameObject.tag == "Door_Large" )
        {
            gameObject.GetComponent<Animator>().Play("largeDoor_Opens");
        } else if (other.tag == "Player" && gameObject.tag == "AccessCard")
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
        }
    }

    public void unlockCityDoor()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
