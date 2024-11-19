using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Capsule")
        {
            SceneManager.LoadScene("alex"); //replace the scene name
        } 
        else if(other.tag == "CityDoor")
        {
            //load last level
        }
    }
}
