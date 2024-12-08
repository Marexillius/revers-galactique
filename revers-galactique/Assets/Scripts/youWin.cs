using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class youWin : MonoBehaviour
{
    public GameObject LastOfTheirKind;
    void Update()
    {
        if (LastOfTheirKind.transform.childCount <= 0)
        {
            SceneManager.LoadScene("Level_finish");
        }
    }
}
