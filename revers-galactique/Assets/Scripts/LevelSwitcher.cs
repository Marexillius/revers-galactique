using System.Collections;
using System.Collections.Generic;
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
        if (other.tag == "Player" && whereIam.name == "Level_Station")
        {
            SceneManager.LoadScene("Level_Outside"); 
        } 
        else if(gameObject.name == "toCity")
        {
            SceneManager.LoadScene("Level_City");
        }
    }

    public void startGame()
    {
        SceneManager.LoadScene("Level_Station"); 
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Level_Start");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
