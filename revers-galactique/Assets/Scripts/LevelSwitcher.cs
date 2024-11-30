using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    private UnityEngine.SceneManagement.Scene whereIam;

    void Start()
    {
        whereIam = SceneManager.GetActiveScene();
        Debug.Log("Name: " + whereIam.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && whereIam.name == "main")
        {
            SceneManager.LoadScene("alex"); 
        } 
        else if(other.tag == "CityDoor")
        {
            //load last level
        }
    }

    public void startGame()
    {
        SceneManager.LoadScene("main"); 
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
